using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    [SerializeField] private GameObject debrisPrefab;
    [SerializeField] private Sprite damagedSprite;
    [SerializeField] private Sprite junkedSprite;
    [SerializeField] private float health = 4f;
    private Rigidbody2D rb;
    private float maxHealth;
    private SpriteRenderer spriteR;
    private bool canTakeDamage = false;

    private void Start()
    {
        maxHealth = health;
        spriteR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DamageTimer());
    }
    private void TakeDamage(float damage) 
    {
        if (canTakeDamage == true) 
        {
            health = health - damage;

            if (health >= maxHealth / 2 && health < maxHealth)
            {
                spriteR.sprite = damagedSprite;
            }

            else if (health > 0 && health < maxHealth / 2)
            {
                spriteR.sprite = junkedSprite;
            }

            else if (health <= 0)
            {
                if (debrisPrefab != null)
                {
                    Instantiate(debrisPrefab);
                }

                Destroy(gameObject);
            }
        }
        
    }

    IEnumerator DamageTimer() 
    {
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.CompareTag("Ball") && col.relativeVelocity.magnitude > 1))
        {
            TakeDamage(col.gameObject.GetComponent<AnimalBall>().powerLevel);
        }

        else if (col.gameObject.CompareTag("Metal") && col.relativeVelocity.magnitude > 1) 
        {
            TakeDamage(5);
        }

        else if (col.gameObject.CompareTag("Structure") && (col.relativeVelocity.magnitude > 1 || rb.velocity.magnitude > 1))
        {
            TakeDamage(3);
        }

        else if (col.gameObject.CompareTag("Ground") && rb.velocity.magnitude > 1) 
        {
            TakeDamage(3);
        }
    }

}

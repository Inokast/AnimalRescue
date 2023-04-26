using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    [SerializeField] private GameObject debrisPrefab;
    [SerializeField] private Sprite damagedSprite;
    [SerializeField] private Sprite junkedSprite;
    [SerializeField] private float health = 4f;
    private float maxHealth;
    private SpriteRenderer spriteR;

    private void Start()
    {
        maxHealth = health;
        spriteR = GetComponent<SpriteRenderer>();
    }
    private void TakeDamage(float damage) 
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if ( col.gameObject.CompareTag("Ball") && col.relativeVelocity.magnitude * col.gameObject.GetComponent<Rigidbody2D>().mass > health) 
        {
            TakeDamage(col.relativeVelocity.magnitude);
        }
    }

}

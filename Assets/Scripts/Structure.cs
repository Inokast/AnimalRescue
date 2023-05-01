using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    [SerializeField] private int structureTypeID = 0; // 0 = glass, 1 = wood, 2 = stone, 3 = metal. Used to find correct sound effect
    [SerializeField] private GameObject[] debrisPrefabs;
    [SerializeField] private Sprite damagedSprite;
    [SerializeField] private Sprite junkedSprite;
    [SerializeField] private float health = 4f;
    private Rigidbody2D rb;
    private float maxHealth;
    private SpriteRenderer spriteR;
    private bool canTakeDamage = false;
    private SoundFXController sfx;

    private void Start()
    {
        maxHealth = health;
        spriteR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        sfx = FindObjectOfType<SoundFXController>();
        StartCoroutine(DamageTimer());
    }
    private void TakeDamage(float damage) 
    {
        if (canTakeDamage == true) 
        {
            health = health - damage;

            if (health >= maxHealth / 2 && health < maxHealth)
            {
                if (spriteR.sprite != damagedSprite) 
                {
                    spriteR.sprite = damagedSprite;
                    switch (structureTypeID)
                    {
                        case 0:
                            sfx.PlayGlassHit();
                            break;
                        case 1:
                            sfx.PlayThudHit();
                            break;
                        case 2:
                            sfx.PlayThudHit();
                            break;
                        case 3:
                            sfx.PlayMetalHit();
                            break;

                        default:
                            sfx.PlayThudHit();
                            break;
                    }
                }                
            }

            else if (health > 0 && health < maxHealth / 2)
            {
                if (spriteR.sprite != junkedSprite) 
                {
                    spriteR.sprite = junkedSprite;
                    switch (structureTypeID)
                    {
                        case 0:
                            sfx.PlayGlassHit();
                            break;
                        case 1:
                            sfx.PlayThudHit();
                            break;
                        case 2:
                            sfx.PlayThudHit();
                            break;
                        case 3:
                            sfx.PlayMetalHit();
                            break;

                        default:
                            sfx.PlayThudHit();
                            break;
                    }
                }              
            }

            else if (health <= 0)
            {
                if (debrisPrefabs.Length > 0)
                {
                    int random = Random.Range(0, debrisPrefabs.Length - 1);
                    GameObject debris = Instantiate(debrisPrefabs[random]);
                    debris.transform.position = transform.position;
                }

                switch (structureTypeID)
                {
                    case 0:
                        sfx.PlayGlassBreak();
                        break;
                    case 1:
                        sfx.PlayWoodBreak();
                        break;
                    case 2:
                        sfx.PlayStoneBreak();
                        break;
                    case 3:
                        sfx.PlayMetalBreak();
                        break;

                    default:
                        sfx.PlayThudHit();
                        break;
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
            TakeDamage(4);
        }

        else if (col.gameObject.CompareTag("Structure") && (col.relativeVelocity.magnitude > 1 || rb.velocity.magnitude > 1))
        {
            TakeDamage(2);
        }

        else if (col.gameObject.CompareTag("Ground") && rb.velocity.magnitude > 1) 
        {
            TakeDamage(2);
        }
    }

}

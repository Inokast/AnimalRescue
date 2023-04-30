using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBall : MonoBehaviour
{
    private LevelManager levelManager;
    public int powerLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();   
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Goal"))
        {
            print("Collided with goal");
            levelManager.ChangeScore(1);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Goal"))
        {
            levelManager.ChangeScore(-1);
        }
    }
    
}

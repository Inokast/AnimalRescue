using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBall : MonoBehaviour
{
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();   
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Goal")) 
        {
            levelManager.ChangeScore(1);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Goal"))
        {
            levelManager.ChangeScore(-1);
        }
    }
}

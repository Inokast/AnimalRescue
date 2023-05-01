using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBall : MonoBehaviour
{
    [SerializeField] private int animalTypeID = 0; // 0 = dog, 1 = cow, 2 = bird, 3 = elephant, 4 = frog. Used to find correct sound effect
    private SoundFXController sfx;
    private LevelManager levelManager;
    public int powerLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SoundFXController>();
        levelManager = FindObjectOfType<LevelManager>();   
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Goal"))
        {
            switch (animalTypeID)
            {
                case 0:
                    sfx.PlayDogSound();
                    break;
                case 1:
                    sfx.PlayCowSound();
                    break;
                case 2:
                    sfx.PlayBirdSound();
                    break;
                case 3:
                    sfx.PlayElephantSound();
                    break;
                case 4:
                    sfx.PlayFrogSound();
                    break;

                default:
                    sfx.PlayFrogSound();
                    break;
            }
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

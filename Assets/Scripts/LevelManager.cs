using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private LevelTransitionScreen transition;
    [SerializeField] private string nextLevelString;

    private void Start()
    {
        transition = FindObjectOfType<LevelTransitionScreen>();
    }
    IEnumerator RestartLevel()
    {
        transition.StartTransition();

        yield return new WaitForSeconds(transition.transitionTime);

        string currentScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentScene);
    }

    IEnumerator LoadNextLevel()
    {
        transition.StartTransition();

        yield return new WaitForSeconds(transition.transitionTime);

        SceneManager.LoadScene(nextLevelString);
    }

    //This function is mainly for the level selector feature in the main menu
    public void LevelSelectbutton(string newLevelString) 
    {
        nextLevelString = newLevelString;
        StartCoroutine(LoadNextLevel());
    }
    public void NextLevel()
    {
        StartCoroutine(LoadNextLevel());
    }

    public void Restart()
    {
        StartCoroutine(RestartLevel());
    }
}

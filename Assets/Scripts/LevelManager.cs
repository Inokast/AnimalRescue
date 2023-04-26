using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private LevelTransitionScreen transition;
    [SerializeField] private string nextLevelString;

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

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Menu")
        {
            SceneManager.LoadScene("Level1");
        }

        if (currentScene == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }

        if (currentScene == "Level2")
        {
            SceneManager.LoadScene("Level3");
        }

        if (currentScene == "Level3")
        {
            SceneManager.LoadScene("EndScreen");
        }

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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private LevelTransitionScreen transition;
    [SerializeField] private string nextLevelString;
    private UIController ui;

    [Header("Level Settings")]
    [SerializeField] private int levelGoal;
    [SerializeField] private bool timerOn = false;
    [SerializeField] private TextMeshProUGUI timerText;
    private int animalsSecured = 0;


    //[SerializeField] private Sprite[] animalTypes;
    

    private void Start()
    {
        ui = FindObjectOfType<UIController>();
        transition = FindObjectOfType<LevelTransitionScreen>();
        if (SceneManager.GetActiveScene().name != "Menu") 
        {
            ui.UpdateGoal(animalsSecured, levelGoal);

            
        }
    }

    public void StartLevel() 
    {

    }

    public void ChangeScore(int num) 
    {
        animalsSecured += num;
        ui.UpdateGoal(animalsSecured, levelGoal);
        CheckForVictory();
    }

    public void CheckForVictory() 
    {
        if (animalsSecured == levelGoal) 
        {
            ui.ShowEndPanel();
        }
    }

    public void PauseGame() 
    {
        Time.timeScale = 0;
        
    }

    public void ResumeGame() 
    {
        Time.timeScale = 1;
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
    public void LevelSelectButton(string newLevelString) 
    {
        ResumeGame();
        nextLevelString = newLevelString;
        StartCoroutine(LoadNextLevel());
    }
    public void NextLevel()
    {
        ResumeGame();
        StartCoroutine(LoadNextLevel());
    }

    public void Restart()
    {
        ResumeGame();
        StartCoroutine(RestartLevel());
    }
}

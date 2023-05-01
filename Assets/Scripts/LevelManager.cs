using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private SoundFXController sfx;
    [Header("Level Configuration")]
    private LevelTransitionScreen transition;
    [SerializeField] private string nextLevelString;
    private UIController ui;
    [SerializeField] private int playMusicID = 0;
    private BGMController bgm;

    [Header("Objective Settings")]
    [SerializeField] private int levelGoal;
    [SerializeField] private float timerDuration = 100;
    [SerializeField] private TextMeshProUGUI timerText;
    private int animalsSecured = 0;
    

    private void Start()
    {
        ui = FindObjectOfType<UIController>();
        transition = FindObjectOfType<LevelTransitionScreen>();
        bgm = FindObjectOfType<BGMController>();
        sfx = FindObjectOfType<SoundFXController>();
        if (SceneManager.GetActiveScene().name != "Menu") 
        {
            ui.UpdateGoal(animalsSecured, levelGoal);
            StartLevel();
        }
        bgm.PlayMusicWithID(playMusicID);
    }

    public void StartLevel() 
    {
        StartCoroutine(CountdownTimer());
    }

    private IEnumerator CountdownTimer() 
    {
        float minutes;
        float seconds;
        while (timerDuration > 0)
        {
            timerDuration -= Time.deltaTime;
            minutes = Mathf.FloorToInt(timerDuration / 60);
            seconds = Mathf.FloorToInt(timerDuration % 60);
            timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
            yield return null;
        }
        timerDuration = 0;
        minutes = Mathf.FloorToInt(timerDuration / 60);
        seconds = Mathf.FloorToInt(timerDuration % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        timerText.color = Color.red;
        ui.ShowEndPanel(false);
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
            StopAllCoroutines();
            ui.ShowEndPanel(true);
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
        sfx.PlayLoadingLevel();
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

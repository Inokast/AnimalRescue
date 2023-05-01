using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    private LevelTransitionScreen transition;

    [Header("Level Connections")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseDetailsPanel;
    [SerializeField] private GameObject levelEndPanel;

    

    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject pauseButton;

    [SerializeField] private TextMeshProUGUI endMessageText;
    [SerializeField] private TextMeshProUGUI goalText;

    private LevelManager levelManager;


    [Header("Menu Connections")]
    [SerializeField] GameObject instructionPanel;
    [SerializeField] GameObject[] instructionPanels;

    [SerializeField] GameObject creditsPanel;

    [SerializeField] GameObject levelSelectPanel;

    private int currentPage = 0;

    private SoundFXController sfx;
    private BGMController bgm;

    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SoundFXController>();
        bgm = FindObjectOfType<BGMController>();
        transition = FindObjectOfType<LevelTransitionScreen>();
        levelManager = FindObjectOfType<LevelManager>();

    }

    public void UpdateGoal(int currentScore, int levelGoal) // Updates the animal goal counter in the UI during a level
    {
        goalText.text = "Animals Secured: " + currentScore.ToString() + " / " + levelGoal;
    }

    #region Level UI

    public void PauseButton() 
    {
        sfx.PlaySelect();

        if (pausePanel.activeSelf == false)
        {
            pausePanel.SetActive(true);
            levelManager.PauseGame();
        }

        else 
        {
            levelManager.ResumeGame();
            pausePanel.SetActive(false);            
        }
        
    }

    public void NextLevelButton() 
    {
        sfx.PlayLoadingLevel();
        levelManager.NextLevel();
    }
    public void RetryButton() 
    {
        sfx.PlaySelect();
        levelManager.Restart();
    }

    public void ReturnToMenuButton() 
    {
        sfx.PlayLoadingLevel();
        levelManager.LevelSelectButton("Menu");
    }

    public void ShowEndPanel(bool playerWon) 
    {
        PauseButton();
        pauseButton.SetActive(false);
        pauseDetailsPanel.SetActive(false);
        levelEndPanel.SetActive(true);

        if (playerWon == false)
        {
            sfx.PlayFailure();
            endMessageText.text = ("Time's up! You were spotted...");
            retryButton.SetActive(true);
            nextLevelButton.SetActive(false);

        }

        else 
        {
            sfx.PlayLevelCompleted();
            endMessageText.text = ("Level Cleared!");
            retryButton.SetActive(false);
            nextLevelButton.SetActive(true);
        }

    }

    #endregion

    #region Menu UI
    
    public void LoadInstructions()
    {
        sfx.PlaySelect();
        instructionPanel.SetActive(true);
    }

    public void LoadCredits()
    {
        sfx.PlaySelect();
        creditsPanel.SetActive(true);
    }

    public void LoadLevelSelect() 
    {
        sfx.PlaySelect();
        levelSelectPanel.SetActive(true);
    }

    public void LoadMenu()
    {
        sfx.PlaySelect();
        instructionPanel.SetActive(false);
        creditsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
    }

    public void QuitGame()
    {
        sfx.PlaySelect();
        Application.Quit();
    }

    public void NextPage() // On instructions menu
    {
        sfx.PlaySelect();
        int lastPage = currentPage;
        currentPage++;

        if (currentPage >= instructionPanels.Length)
        {
            currentPage = 0;
        }

        instructionPanels[currentPage].SetActive(true);
        instructionPanels[lastPage].SetActive(false);
    }

    #endregion
}

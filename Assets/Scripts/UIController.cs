using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Level Connections")]
    [SerializeField] public Text goalText;
    [SerializeField] GameObject keyOutlineIcon;
    [SerializeField] GameObject keyIcon;
    private LevelTransitionScreen transition;

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

    }

    public void UpdateGoal(int currentScore, int levelGoal) // Updates the animal goal counter in the UI during a level
    {
        goalText.text = "X " + currentScore.ToString() + " / " + levelGoal;
    }

    #region Menu UI
    public void ColorScore() // Changes star counter color to yellow
    {
        goalText.color = Color.yellow;
    }
    
    public void LoadInstructions()
    {
        instructionPanel.SetActive(true);
        //SceneManager.LoadScene("Instructions");
    }

    public void LoadCredits()
    {
        creditsPanel.SetActive(true);
        //sfx.PlayMenuClick();
        //SceneManager.LoadScene("Credits");
    }

    public void LoadLevelSelect() 
    {
        levelSelectPanel.SetActive(true);
    }

    public void LoadMenu()
    {
        instructionPanel.SetActive(false);
        creditsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        //sfx.PlayMenuClick();
        //SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        //sfx.PlayMenuClick();
        Application.Quit();
    }

    public void NextPage() // On instructions menu
    {
        //sfx.PlayMenuClick();
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

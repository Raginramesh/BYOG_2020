using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManagerScript : MonoBehaviour
{

    private GameObject gameManager;
    private LevelManager levelManager;
    public GameObject pausePanel;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        levelManager = gameManager.GetComponent<LevelManager>();
        
        levelManager.CheckRetry();
        PlayerPrefs.SetInt("Retry", 0);
    }
    public void OnQuitToMenuButtonClick()
    {
        //Destroy(gameManager);
        PlayerPrefs.SetInt("Level", 0);
        SceneManager.LoadScene(0);
        
    }

    public void OnPauseButtonClick()
    {
        pausePanel.SetActive(true);
    }

    public void OnResumeButtonClick()
    {
        pausePanel.SetActive(false);
    }

    public void OnRetryButtonClick()
    {
        levelManager.RetryLevel();
    }

    public void OnNextButtonClick()
    {
        StartCoroutine(levelManager.NextLevel());
    }

    public void OnPlaybuttonClick()
    {
        levelManager.OnPlayButtonClick();
    }
}

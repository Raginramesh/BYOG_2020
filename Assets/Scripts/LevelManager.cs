using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameManager gm;
    public int currentLevel = 0;
    public GameObject menuScreen;
    public GameObject gameScreen;
    
    private PlayerController player;

    void Start()
    {
        if (gm == null)
            gm = this.GetComponent<GameManager>();
        player = gm.player.GetComponent<PlayerController>();
    }

    public void RetryLevel()
    {
        PlayerPrefs.SetInt("Retry", 1);
        currentLevel = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(currentLevel);
    }

    public void OnPlayButtonClick()
    {
        menuScreen.SetActive(false);
        gameScreen.SetActive(true);
        player.enabled = true;
    }

    public void NextLevel()
    {
        currentLevel = PlayerPrefs.GetInt("Level");
        currentLevel++;

        if (currentLevel < SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("Level", currentLevel);
            SceneManager.LoadScene(currentLevel);
        }
        else
        {
            currentLevel = 0;
            PlayerPrefs.SetInt("Level", currentLevel);

            SceneManager.LoadScene(currentLevel);
        }
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void CheckRetry()
    {
        currentLevel = PlayerPrefs.GetInt("Level");
        if ((PlayerPrefs.GetInt("Retry") == 1) && (currentLevel == 0))
        {
            OnPlayButtonClick();
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Level", 0);
    }
}

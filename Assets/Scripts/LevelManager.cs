using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameManager gm;
    public List<GameObject> levels;
   
    public int currentLevel = 0;


    void Start()
    {
        if (gm == null)
            gm = this.GetComponent<GameManager>();

        StartGame();
    }

    private void Update()
    {
        
    }

    public void StartGame()
    {
        levels[currentLevel].SetActive(true);
    }

    public void EndLevel()
    {
        if(currentLevel < levels.Count)
        {
            levels[currentLevel].SetActive(false);
            currentLevel += 1;
            levels[currentLevel].SetActive(true);
        }
    }
}

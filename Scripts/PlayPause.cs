using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayPause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static PlayPause instance;
    public GameObject pauseMenuUI;
    public GameObject GameOverUI;
    public GameObject GameOverPrefab;
    public Vector3 GameOverPosition = new Vector3(0f, 7f, 0f);
    

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        
        SoundManagerScript.PlaySound("ButtonClick");
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        
        SoundManagerScript.PlaySound("ButtonClick");
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Menu()
    {

        SoundManagerScript.PlaySound("ButtonClick");
        Debug.Log("Menu Clicked");
        SceneManager.LoadScene("BEGIN");
        Time.timeScale = 1f;
    }
    public void Exit()
    {

        SoundManagerScript.PlaySound("ButtonClick");
        Debug.Log("Quit Application");
        Application.Quit();
    }
    public void GameOver()
    {

        GameOverUI.SetActive(true);
        // adding the game over effect and sounds
        // resolves issue #6
        Instantiate(GameOverPrefab, GameOverPosition, Quaternion.identity);
        InstantiatePrefab.instance.GameOverTextChange();
        Time.timeScale = 0.7f;

    }
    public void RestartGame()
    {

        AudioListener.pause = false;
        SoundManagerScript.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void NextLevel()
    {

        SoundManagerScript.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}


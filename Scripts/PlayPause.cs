using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayPause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static PlayPause instance;
    public GameObject pauseMenuUI;
    public GameObject GameOverUI;
    

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
    /*public void LevelWon()
    {
        LevelWonUI.SetActive(true);

    }*/
    public void Resume()
    {
        // Handheld.Vibrate();
        SoundManagerScript.PlaySound("ButtonClick");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        // Handheld.Vibrate();
        SoundManagerScript.PlaySound("ButtonClick");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Menu()
    {
        // Handheld.Vibrate();
        SoundManagerScript.PlaySound("ButtonClick");
        Debug.Log("Menu Clicked");
        SceneManager.LoadScene("BEGIN");
    }
    public void Exit()
    {
        // Handheld.Vibrate();
        SoundManagerScript.PlaySound("ButtonClick");
        Debug.Log("Quit Application");
        Application.Quit();
    }
    public void GameOver()
    {

        GameOverUI.SetActive(true);
        // gameOverScore.text = "You Killed " + UpdateScore.instance.returnKills().ToString() + " Ants";
        InstantiatePrefab.instance.GameOverTextChange();
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        // Handheld.Vibrate();
        SoundManagerScript.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void NextLevel()
    {
        // Handheld.Vibrate();
        SoundManagerScript.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}


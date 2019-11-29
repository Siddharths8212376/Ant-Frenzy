using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginScript : MonoBehaviour
{
    public GameObject NextLevelUI;
    public GameObject thisLevelUI;
    public void StartUI()
    {
        
        // NextLevelUI.SetActive(true);
        // thisLevelUI.SetActive(false);
    }
    public void ExitGame()
    {
        // Handheld.Vibrate();
        SoundManagerScript.PlaySound("ButtonClick");
        Application.Quit();
        Debug.Log("Quit");
    }
    public void StartGame()
    {
        // Handheld.Vibrate();
        SoundManagerScript.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
}


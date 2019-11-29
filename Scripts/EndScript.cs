using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScript : MonoBehaviour
{
    public void EndGame()
    {
        // Handheld.Vibrate();
        SoundManagerScript.PlaySound("ButtonClick");
        Application.Quit();
    }
    public void RestartGame()
    {
        // Handheld.Vibrate();
        SoundManagerScript.PlaySound("ButtonClick");
        SceneManager.LoadScene("BEGIN");
    }
}

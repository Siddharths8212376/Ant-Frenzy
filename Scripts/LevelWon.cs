using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWon : MonoBehaviour
{
    // Start is called before the first frame update
    //public static LevelWon instance;
    public GameObject LevelWonUI;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WinLevel()
    {
        LevelWonUI.SetActive(true);
        // jump to new scene

    }
}

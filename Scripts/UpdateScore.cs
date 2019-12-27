using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    // public PinchDestroy pinch;
    public SimpleHealthBar healthBar;
    public static UpdateScore instance;
    // Start is called before the first frame update

    // create the game object for specifying the progress
    public SimpleHealthBar progressBar;

    public int kills = 1;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealth()
    {
        // we should add the current time as well as update the progressbar
        float up_time = InstantiatePrefab.instance.currentTime;
        up_time += 1f;

        healthBar.UpdateBar( up_time, InstantiatePrefab.instance.startingTime);
        progressBar.UpdateBar((float)kills, (float)InstantiatePrefab.instance.antTarget);
        kills += 1;
        /*if(kills > InstantiatePrefab.instance.returnTarget())
        {
            InstantiatePrefab.instance.WinLevel();
        }*/
    }
    public int returnKills()
    {
        return (kills - 1);
    }
}

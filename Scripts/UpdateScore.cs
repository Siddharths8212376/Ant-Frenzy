using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    // public PinchDestroy pinch;
    public SimpleHealthBar healthBar;
    public static UpdateScore instance;
    // Start is called before the first frame update
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
        healthBar.UpdateBar( (float)kills, (float)InstantiatePrefab.instance.returnLim());
        kills += 1;
        if(kills > InstantiatePrefab.instance.returnLim())
        {
            InstantiatePrefab.instance.WinLevel();
        }
    }
    public int returnKills()
    {
        return (kills - 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InstantiatePrefab : MonoBehaviour
{
    public GameObject AntPrefab;
    public LevelWon won;
    public static InstantiatePrefab instance;
    public bool playOnce = true;
    public static event Action SecondOn = delegate { };
    // adding a resolution to issue #7
    // declare the event level won
    public bool LevelWon = false;
    public bool LevelLost = false;
    // variable to check whether the ant limit is reached or not
    public bool limitReached = false;
    public GameObject congratsEffectPrefab;
    public Vector3 congratsPosition = new Vector3(0f, 6f, 0f);
    public float min_X, min_Y, max_X, max_Y;
    public bool is_update = false;
    public int count = 0;
    public int getTotalCount = 0;
    public float multiplier = 1.2f;
    float screenx;
    float screeny;
    public int limitOfAntsOnScreen = 25;
    public GameObject border1;
    public GameObject border2;
    public GameObject border3;
    public GameObject border4;
    // time limit
    public SimpleHealthBar timeBar;
    // ant limit
    public SimpleHealthBar antLimitBar;
    public TextMeshProUGUI levelWon;
    public TextMeshProUGUI gameOverScore;
    public TextMeshProUGUI targetInit;
    public GameObject LevelWonUI;
    public float delta_add = 0.1f;
    public float start_del = 0.6f;
    public int antSpawnCount = 15;
    public int antTarget = 35;
    public float update_time;
    public float init_delay = 0.4f;
    // Start is called before the first frame update

    // adding a time delay to resolve the procedural issue
    public float currentTime = 0f;
    // setting the start time as 2 minutes
    public float startingTime = 120f;
    public float delTime = 0f;

    void Start()
    {
        //  set the current time as starting time
        currentTime = startingTime;
        delTime = currentTime;
        Vector2 screenhw = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenx = screenhw.x;
        screeny = screenhw.y;
        border1.transform.localScale = new Vector2(screenx, 0.18f);
        border2.transform.localScale = new Vector2(screenx, 0.05f);
        border3.transform.localScale = new Vector2(0.02f, screeny);
        border4.transform.localScale = new Vector2(0.02f, screeny);
        Debug.Log(screenx);
        Debug.Log(screeny);
        border1.transform.position = new Vector2(0, screeny);
        border2.transform.position = new Vector2(0, -screeny);
        border3.transform.position = new Vector2(screenx, 0);
        border4.transform.position = new Vector2(-screenx, 0);
        targetInit.text = antTarget.ToString();

        StartCoroutine(Instantiate_P());
        if(instance == null)
        {
            instance = this;
        }
    }


    public IEnumerator Instantiate_P()
    {
        float[] x_coords = new float[antSpawnCount] ;
        float[] y_coords = new float[antSpawnCount] ;
        int count_len = 0;
        int i = 0;
        for( i = 0; i < antSpawnCount; i++)
        {
            x_coords[i] = UnityEngine.Random.Range(min_X, max_X);
            y_coords[i] = UnityEngine.Random.Range(min_Y, max_Y);

        }

        int total_len = x_coords.Length;
        yield return new WaitForSeconds(init_delay);
        while (count_len < x_coords.Length)
        {



            if (limitReached == false)
            {
                Vector2 points = new Vector2(x_coords[count_len], y_coords[count_len]);
                SoundManagerScript.PlaySound("Energy");
                Instantiate(AntPrefab, points, Quaternion.identity);



                count_len += 1;
                getTotalCount += 1;
                total_len -= 1;


                float x = (float)getTotalCount;
                float time_val = (float)limitOfAntsOnScreen;
                update_time = time_val - x;


                antLimitBar.UpdateBar(x, (float)limitOfAntsOnScreen);

                yield return new WaitForSeconds(start_del + delta_add);
            }
            else
            {
                break;
            }
        }



    }

    /*Vector2 getRandom()
    {
        float randomX = Random.Range(min_X, max_X);
        float randomY = Random.Range(min_Y, max_Y);
        return new Vector2(randomX, randomY);
    }*/
    public void decrementCount()
    {
        getTotalCount -= 1;
        antLimitBar.UpdateBar((float)getTotalCount, (float)limitOfAntsOnScreen);
    }
    public int returnCount()
    {
        return getTotalCount;
    }
    public int returnLim()
    {
        return limitOfAntsOnScreen;
    }
    public void WinLevel()
    {
        // level won panel score value set up
        LevelWon = true;
        Time.timeScale = 0.6f;
        levelWon.text = UpdateScore.instance.returnKills().ToString() ;
        LevelWonUI.SetActive(true);

        // adding the game won effects and applause
        // resolves issues #6
        Instantiate(congratsEffectPrefab, congratsPosition, Quaternion.identity);
    }
    public void GameOverTextChange()
    {
        gameOverScore.text = UpdateScore.instance.returnKills().ToString() ;
    }
    public int returnTarget()
    {
        return antTarget;
    }

    // adding the update function
    void Update()
    {
        if(playOnce == true)
        {
            SoundManagerScript.PlaySound("TickTock");
            playOnce = false;
        }
        currentTime -= 1 * Time.deltaTime;
        if((int)(delTime - currentTime) == 1 && limitReached == false)
        {
            
            SecondOn();
            // play one shot time lapse
            if (delTime > 10)
            {
                SoundManagerScript.PlaySound("TickTock");
            }
            else
            {
                SoundManagerScript.PlaySound("Clink");
            }
            delTime -= 1f;
        }
        timeBar.UpdateBar(currentTime, startingTime);

        if (currentTime <= 0f)
        {
            currentTime = 0f;
        }
        if ((currentTime == 0 && getTotalCount != 0) || getTotalCount > limitOfAntsOnScreen)
        {
            // gameOver
            if (LevelLost == false)
            {
                string gameOverReason;
                limitReached = true;
                LevelLost = true;
                if (currentTime == 0)
                {
                    gameOverReason = "Time's UP! \n\n Better Luck Next Time;)";
                }
                else
                {
                    gameOverReason = "Ant Limit Reached! \n\n Try Harder Next Time ;)";
                }
                PlayPause.instance.GameOver(gameOverReason) ;

            }

        }
        if (currentTime != 0 && (UpdateScore.instance.returnKills() == antTarget))
        {
            // for each frame the time remains a constant then
            currentTime += 1 * Time.deltaTime;
            // also stop spawning ants altogether
            limitReached = true;
            // winLevel
            if (LevelWon == false)
            {
                WinLevel();

            }
        }
    }
}



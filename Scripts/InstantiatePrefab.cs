using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InstantiatePrefab : MonoBehaviour
{
    public GameObject AntPrefab;
    public LevelWon won;
    public static InstantiatePrefab instance;
    public float min_X, min_Y, max_X, max_Y;
    public bool is_update = false;
    public int count = 0;
    public int getTotalCount = 0;
    public float multiplier = 1.5f;
    float screenx;
    float screeny;
    public int lim = 12;
    public GameObject border1;
    public GameObject border2;
    public GameObject border3;
    public GameObject border4;
    public SimpleHealthBar healthBar;
    public TextMeshProUGUI levelWon;
    public TextMeshProUGUI gameOverScore;
    public GameObject LevelWonUI;
    public float delta_add = 0.1f;
    public float start_del = 0.6f;
    public int ant_count = 15;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 screenhw = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenx = screenhw.x;
        screeny = screenhw.y;
        border1.transform.localScale = new Vector2(screenx, 0.1f);
        border2.transform.localScale = new Vector2(screenx, 0.1f);
        border3.transform.localScale = new Vector2(0.02f, screeny);
        border3.transform.localScale = new Vector2(0.02f, screeny);
        Debug.Log(screenx);
        Debug.Log(screeny);
        border1.transform.position = new Vector2(0, screeny);
        border2.transform.position = new Vector2(0, -screeny);
        border3.transform.position = new Vector2(screenx, 0);
        border4.transform.position = new Vector2(-screenx, 0);

        // Invoke("Instantiate_P", 2);
        StartCoroutine(Instantiate_P());
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        // Do the initial instantiation
        if (is_update == false)
        {
            Invoke("Instantiate_P", 2000);
            is_update = true;
        }

    }*/

    public IEnumerator Instantiate_P()
    {
        float[] x_coords = new float[ant_count] ;
        float[] y_coords = new float[ant_count] ;
        int count_len = 0;
        int i = 0;
        for( i = 0; i < ant_count; i++)
        {
            x_coords[i] = Random.Range(min_X, max_X);
            y_coords[i] = Random.Range(min_Y, max_Y);

        }

        int total_len = x_coords.Length;

        while (count_len < x_coords.Length)
        {
            float x = (float)getTotalCount * multiplier;   
            healthBar.UpdateBar(x, (float)lim);

            Vector2 points = new Vector2(x_coords[count_len], y_coords[count_len]);
            SoundManagerScript.PlaySound("Energy");
            Instantiate(AntPrefab, points, Quaternion.identity);
            yield return new WaitForSeconds(start_del + delta_add);
            count_len += 1;
            getTotalCount += 1;
            total_len -= 1;
            delta_add += 0.03f;
            if (getTotalCount >= lim)
            {
                PlayPause.instance.GameOver();
                break;
            }
            if (x >= (float)lim)
            {
                Time.timeScale = 0f;
                // LevelWonUI.SetActive(true);
                PlayPause.instance.GameOver();
            }
            /*if (total_len == 0)
            {
                // Level Won
                // PlayPause.instance.LevelWon();
                // won.WinLevel();
                Time.timeScale = 0f;
                LevelWonUI.SetActive(true);
            }*/

        }
        
        // Invoke("RepeatLoop");

    }
   /* void RepeatLoop()
    {
        InvokeRepeating("Insta", 0, 5);
    }
    void Insta()
    {
        Instantiate(AntPrefab, getRandom(), Quaternion.identity);
    }*/
    Vector2 getRandom()
    {
        float randomX = Random.Range(min_X, max_X);
        float randomY = Random.Range(min_Y, max_Y);
        return new Vector2(randomX, randomY);
    }
    public void decrementCount()
    {
        getTotalCount -= 1;
        healthBar.UpdateBar((float)getTotalCount, (float)lim);
    }
    public int returnCount()
    {
        return getTotalCount;
    }
    public int returnLim()
    {
        return lim;
    }
    public void WinLevel()
    {
        Time.timeScale = 0f;
        levelWon.text = "You Killed " + UpdateScore.instance.returnKills().ToString() + " Ants";
        LevelWonUI.SetActive(true);
    }
    public void GameOverTextChange()
    {
        gameOverScore.text = "You Killed " + UpdateScore.instance.returnKills().ToString() + " Ants";
    }
}


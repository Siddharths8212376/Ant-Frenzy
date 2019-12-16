using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InstantiatePrefab : MonoBehaviour
{
    public GameObject AntPrefab;
    public LevelWon won;
    public static InstantiatePrefab instance;

    public GameObject congratsEffectPrefab;
    public Vector3 congratsPosition = new Vector3(0f, 6f, 0f);
    public float min_X, min_Y, max_X, max_Y;
    public bool is_update = false;
    public int count = 0;
    public float getTotalCount = 0f;
    public float multiplier = 1.2f;
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
    public TextMeshProUGUI targetInit;
    public GameObject LevelWonUI;
    public float delta_add = 0.1f;
    public float start_del = 0.6f;
    public int antSpawnCount = 15;
    public int antTarget = 35;
    public float update_time;
    public float init_delay = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
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
        targetInit.text = "Kills Left: " + antTarget.ToString();

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
            x_coords[i] = Random.Range(min_X, max_X);
            y_coords[i] = Random.Range(min_Y, max_Y);

        }

        int total_len = x_coords.Length;
        yield return new WaitForSeconds(init_delay);
        while (count_len < x_coords.Length)
        {
            float x = (float)getTotalCount * multiplier;
            float time_val = (float)lim;
            update_time = time_val - x;
            
            healthBar.UpdateBar((float)update_time, (float)lim);

            Vector2 points = new Vector2(x_coords[count_len], y_coords[count_len]);
            SoundManagerScript.PlaySound("Energy");
            Instantiate(AntPrefab, points, Quaternion.identity);
            yield return new WaitForSeconds(start_del + delta_add);
            count_len += 1;
            getTotalCount += 1.0f;
            total_len -= 1;
            if (delta_add <= 2.0f)
            {
                delta_add += 0.03f;
            }
            else
            {
                delta_add += 0.2f;
            }
            if (getTotalCount > lim)
            {

                PlayPause.instance.GameOver();
                break;
            }
            if (x >= (float)lim)
            {
                Time.timeScale = 0f;
                PlayPause.instance.GameOver();
            }

        }
        

    }

    Vector2 getRandom()
    {
        float randomX = Random.Range(min_X, max_X);
        float randomY = Random.Range(min_Y, max_Y);
        return new Vector2(randomX, randomY);
    }
    public void decrementCount()
    {
        getTotalCount -= 1.0f;
        float current_health = update_time;
        float update_health = current_health + 0.5f;
        // update_time += update_health;
        healthBar.UpdateBar((float)update_health, (float)lim);
    }
    public float returnCount()
    {
        return getTotalCount;
    }
    public int returnLim()
    {
        return lim;
    }
    public void WinLevel()
    {
        // level won panel score value set up
        Time.timeScale = 0.6f;
        levelWon.text = UpdateScore.instance.returnKills().ToString() ;
        LevelWonUI.SetActive(true);

        // adding the game won effects and applause
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
}


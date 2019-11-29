using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public GameObject ScoreValue;
    public TextMeshProUGUI timeOut;
    public int score;
    public int antCount;
    public int prevCount;
   // public int timeLeft = 100;
   // public int lim_;
    //public bool set = false;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        //prevCount = InstantiatePrefab.instance.returnCount();
        //DecreaseTime();
    }

    // Update is called once per frame
    void Update()
    {
        /*antCount = InstantiatePrefab.instance.returnCount();
        lim_ = InstantiatePrefab.instance.returnLim();
        if (set == false)
        {
            DecreaseTime(); 

            if (antCount >= prevCount) {

                set = false;
            }
            else
            {
                set = true;
            }
            
        }*/

    }
    public void ChangeScore(int AntCount)
    {
        score += AntCount;
        text.text = "Ant Count : " + score.ToString();
    }
    /*public IEnumerator DecreaseTime()
    {
        

        while (timeLeft > 0)
        {
            if (antCount >= prevCount)
            {
                yield return new WaitForSeconds(0.3f);
                timeOut.text = "AntFrenzy In: " + timeLeft.ToString() + "s ";
                timeLeft -= 1;
                prevCount = antCount;
            }
            else if(antCount < prevCount)
            {
                timeLeft += 10;
                prevCount = antCount;
            }
        }
        if(timeLeft == 0)
        {
            PlayPause.instance.GameOver();
        }
        
        

    }*/
}

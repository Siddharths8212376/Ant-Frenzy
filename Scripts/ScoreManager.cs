using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public GameObject ScoreValue;
    // public TextMeshProUGUI timeOut;
    public TextMeshProUGUI targetText;
    public int score;
    public int antCount;
    public int prevCount;
    public int targetLeft;

    // adding the event in the awake method
    // then calling a subroutine based on that
    private void Awake()
    {
        PinchDestroy.AntKilled += RunCo;
        // runco is run coroutine

    }

    // define the co-routine
    public void RunCo()
    {
        StartCoroutine(Pulse());
    }

    // define the co-routine Pulse
    private IEnumerator Pulse()
    {
        for (float i = 1f; i <= 1.2f; i += 0.05f)
        {
            text.rectTransform.localScale = new Vector3(i, i, i);
            targetText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }

        text.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        targetText.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        for (float i = 1.2f; i >= 1f; i -= 0.05f)
        {
            text.rectTransform.localScale = new Vector3(i, i, i);
            targetText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
 
        text.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        targetText.rectTransform.localScale = new Vector3(1f, 1f, 1f);

        
    }

    // define the onDestroy functionality
    private void OnDestroy()
    {
        PinchDestroy.AntKilled -= RunCo;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

    }


    void Update()
    {


    }
    public void ChangeScore(int AntCount)
    {
        score += AntCount;
        text.text = score.ToString();
    }

    public void TargetUpdate()
    {
        // the target get's updated once an ant is killed
        int killed = UpdateScore.instance.returnKills();
        int target = InstantiatePrefab.instance.returnTarget();
        targetLeft = target - killed;
        targetText.text = targetLeft.ToString();
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PinchDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    float touchesPrevPosDiff, touchesCurPosDiff;
    public static PinchDestroy instance;

    // declare a static event action using delegate
    public static event Action AntKilled = delegate { };

    // create the game object for instantiting blood splash

    public GameObject bloodSplash;
    public GameObject bloodStain;

    public int antScore = 1;
    public int killCount = 0;

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
        Vector2 firstTouchPrevPos, secondTouchPrevPos;
        float prevDiff, curDiff, touchDelta;
        Vector2 curDist, prevDist;
        float minPinchSpeed = 5f, varianceInDistances = 5f;
        

        if ((Input.touchCount == 2) && (Input.GetTouch(0).phase == TouchPhase.Moved) && (Input.GetTouch(1).phase == TouchPhase.Moved))
        {

            Vector2 t_0 = Input.GetTouch(0).position;
            Vector2 t_1 = Input.GetTouch(1).position;
            Vector2 test = Camera.main.ScreenToWorldPoint(t_0);
            Vector2 test_one = Camera.main.ScreenToWorldPoint(t_1);

            
            
            if (Physics2D.Raycast(test, (Input.GetTouch(0).position)).collider.tag == "Obstacle" && Physics2D.Raycast(test, (Input.GetTouch(0).position)).collider.gameObject == gameObject && Physics2D.Raycast(test_one, (Input.GetTouch(1).position)).collider.tag == "Obstacle" && Physics2D.Raycast(test_one, (Input.GetTouch(1).position)).collider.gameObject == gameObject)
            {


                  Vector2 prevZero = (Input.GetTouch(0).deltaPosition);
                  Vector2 prevOne = (Input.GetTouch(1).deltaPosition);
                  float minVal = 6f;
                  firstTouchPrevPos = t_0 - prevZero;
                  secondTouchPrevPos = t_1- prevOne;

                  prevDiff = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
                  curDiff = (t_0 - t_1).magnitude;

                  if ((prevDiff - curDiff >= minVal) && ((Input.GetTouch(0).phase == TouchPhase.Moved) && (Input.GetTouch(1).phase == TouchPhase.Moved)))
                  {
                    // the onpinchevent

                    // testing the resolution for issue #7
                   if (InstantiatePrefab.instance.LevelWon == false && PlayPause.instance.LevelLost == false)
                   {
                        Destroy(gameObject);
                        OnPinch();
                   }
                    // Destroy(gameObject);
                  }

    
  
            }
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }


    public void OnPinch()
    {
        // call the event for updating score
        AntKilled();

        SoundManagerScript.PlaySound("squishNew");
        float limit_ = (float)InstantiatePrefab.instance.returnLim();
    
        // resolves issue #4
        Instantiate(bloodSplash, transform.position, Quaternion.identity);

        ScoreManager.instance.ChangeScore(antScore);

        UpdateScore.instance.UpdateHealth();
        InstantiatePrefab.instance.decrementCount();

        // resolves issue #4
        Instantiate(bloodStain, transform.position, Quaternion.identity);
        ScoreManager.instance.TargetUpdate();

    }
    public int returnKillCount()
    {
        return killCount;
    }
}


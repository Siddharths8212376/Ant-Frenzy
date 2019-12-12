﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinchDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    float touchesPrevPosDiff, touchesCurPosDiff;
    public static PinchDestroy instance;
    // create the game object for instantiting blood splash
    public GameObject bloodSplash;
    public GameObject bloodStain;
    //public SimpleHealthBar healthBar;
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
        float speedTouch0, speedTouch1;

        if ((Input.touchCount == 2) && (Input.GetTouch(0).phase == TouchPhase.Moved) && (Input.GetTouch(1).phase == TouchPhase.Moved))
        {
            /*Ray2D raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit2D raycastHit;

            if (Physics2D.Raycast(raycast, out raycastHit))
            {
                Debug.Log("Something Hit");
                if (raycastHit.collider.CompareTag("Obstacle"))
                {
                    Debug.Log("Obstacle Clicked");
                    Invoke("Destroy", 1);
                  /*  Touch touchZero = Input.GetTouch(0);
                    Touch touchOne = Input.GetTouch(1);

                    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                    Vector2 touchOnePrevPos = touchOne.position - touchZero.deltaPosition;

                    float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                    float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                    float deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;
                    if (deltaMagnitudediff < 0)
                    {
                        // pinching event
                        Invoke("Destroy", 1);
                    }
                }
            } */
            Vector2 t_0 = Input.GetTouch(0).position;
            Vector2 t_1 = Input.GetTouch(1).position;
            Vector2 test = Camera.main.ScreenToWorldPoint(t_0);
            Vector2 test_one = Camera.main.ScreenToWorldPoint(t_1);

            
            
            if (Physics2D.Raycast(test, (Input.GetTouch(0).position)).collider.tag == "Obstacle" && Physics2D.Raycast(test, (Input.GetTouch(0).position)).collider.gameObject == gameObject && Physics2D.Raycast(test_one, (Input.GetTouch(1).position)).collider.tag == "Obstacle" && Physics2D.Raycast(test_one, (Input.GetTouch(1).position)).collider.gameObject == gameObject)
            {
                // Invoke("Destroy", 1);

               /* curDist = t_0 - t_1;
                prevDist = (t_0 - Input.GetTouch(0).deltaPosition) - (t_1 - Input.GetTouch(1).position);

                touchDelta = curDist.magnitude - prevDist.magnitude;
                speedTouch0 = Input.GetTouch(0).deltaPosition.magnitude / Input.GetTouch(0).deltaTime;
                speedTouch1 = Input.GetTouch(1).deltaPosition.magnitude / Input.GetTouch(1).deltaTime;

                if((touchDelta + varianceInDistances >= 1)  && (speedTouch0 >= minPinchSpeed) && (speedTouch1 >= minPinchSpeed))
                {
                    // fingers getting closer I guess
                    Destroy(gameObject);
                }*/

                  Vector2 prevZero = (Input.GetTouch(0).deltaPosition);
                  Vector2 prevOne = (Input.GetTouch(1).deltaPosition);
                  float minVal = 8f;
                  firstTouchPrevPos = t_0 - prevZero;
                  secondTouchPrevPos = t_1- prevOne;

                  prevDiff = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
                  curDiff = (t_0 - t_1).magnitude;

                  if ((prevDiff - curDiff > minVal) && ((Input.GetTouch(0).phase == TouchPhase.Moved) && (Input.GetTouch(1).phase == TouchPhase.Moved)))
                  {
                    // the onpinchevent
                    Destroy(gameObject);
                    OnPinch();
                    // Destroy(gameObject);
                  }

                  


                /*
                Vector3 prevPosZero = touchZero.deltaPosition;
                Vector3 prevPosOne = touchOne.deltaPosition;
                Vector2 prePZero = new Vector2(prevPosZero.x, prevPosZero.y);
                Vector2 prePOne = new Vector2(prevPosOne.x, prevPosOne.y);

                Vector2 touchZeroPrevPos = test - Camera.main.ScreenToWorldPoint(prePZero);
                Vector2 touchOnePrevPos = test_one - Camera.main.ScreenToWorldPoint(prePOne);

                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (test - test_one).magnitude;

                float deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;*/

                // for touch 0
                /*Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 currentZero, currentOne, pastPositionZero, pastPositionOne;
                pastPositionZero = touchZero.position;
                pastPositionOne = touchOne.position;

                currentZero.x = Input.GetTouch(0).position.x - pastPositionZero.x;
                currentZero.y = Input.GetTouch(0).position.y - pastPositionZero.y;

                currentOne.x = Input.GetTouch(1).position.x - pastPositionOne.x;
                currentOne.y = Input.GetTouch(1).position.y - pastPositionOne.y;

                float prevMagdelta = (pastPositionZero - pastPositionOne).magnitude;
                float newMagdelta = (currentZero - currentOne).magnitude;

                float deltaMag = prevMagdelta - newMagdelta;

                


                if (deltaMag < 0)
                {
                    // pinching event
                    Destroy(gameObject);
                }*/

            }
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    /*void OnTriggerEnter2D(RaycastHit raycastHit)
    {
        if (raycastHit.collider.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }*/

    public void OnPinch()
    {
        // Handheld.Vibrate();
        SoundManagerScript.PlaySound("AntSquishify");
        float limit_ = (float)InstantiatePrefab.instance.returnLim();
        Instantiate(bloodSplash, transform.position, Quaternion.identity);
       // healthBar.UpdateBar((float)antScore, limit_);
       // UpdateHealth();
        ScoreManager.instance.ChangeScore(antScore);
        UpdateScore.instance.UpdateHealth();
        InstantiatePrefab.instance.decrementCount();
        Instantiate(bloodStain, transform.position, Quaternion.identity);
       // killCount += 1;
        /*if ((float)killCount == limit_)
        {
            // Time.timeScale = 0f;
            // LevelWonUI_.SetActive(true);
            InstantiatePrefab.instance.WinLevel();
        }*/
        Debug.Log(killCount);
    }
    public int returnKillCount()
    {
        return killCount;
    }
}


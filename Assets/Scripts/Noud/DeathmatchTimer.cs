using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathmatchTimer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    float timeTemp;

    private void Start()
    {
        timeTemp = timeRemaining;
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeTemp > 0)
            {
                timeTemp -= Time.deltaTime;
                DisplayTime(timeTemp);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeTemp = 0;
                timerIsRunning = false;
            }
        }
        if (timeTemp <= 0)
        {
            GameManager.instance.EndGame();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTime()
    {
        timeTemp = timeRemaining;
        DisplayTime(timeTemp);
        timerIsRunning = true;
    }

}



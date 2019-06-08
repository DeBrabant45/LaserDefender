using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public static float levelTimer = 30f;
    private Text timerText;

    void Start()
    {
        timerText = GetComponent<Text>();
        Reset();
    }

    public void CountDown()
    {
        levelTimer -= Time.deltaTime;
        timerText.text = levelTimer.ToString("f0");
        //TimeToNextLevel();
    }

    public static void Reset()
    {
        levelTimer = 30;
    }

    private void Update()
    {
        CountDown();
    }
}
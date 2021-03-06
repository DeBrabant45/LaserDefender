﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostReport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDisplayReport();
        InvokeRepeating("DisplayReport", 0, .01f); //Invoking every seconds
    }

    // ** Note to self **
    // Setting a gameObect to inactive will also disable it's script
    // The parent level must be setting an object to inactive so it can re-active it
    void DisplayReport()
    {
        //Once the timer hit's zero pause the screen and set children to display
        if (LevelTimer.levelTimer <= 0)
        {
            //Loop through all the children in GameObject "PostReport"
            for (int i = 0; i < transform.childCount; i++)
            {
                Time.timeScale = 0; // pause
                transform.GetChild(i).gameObject.SetActive(true);
                continue;
            }
        }
    }

    void DontDisplayReport()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
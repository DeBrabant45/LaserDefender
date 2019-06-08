using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginWaveCountDown : MonoBehaviour
{
    public float beginWaveTimer = 5.0f;
    private Text timerText;

    void Start()
    {
        timerText = GetComponent<Text>();
        Reset();
        StartCoroutine("StartDelay");
    }

    private IEnumerator StartDelay()
    {
        float originalTimeScale = 1; // store original time scale in case it was not 1
        Time.timeScale = 0; // pause
        while (beginWaveTimer >= 0f)
        {
            yield return null; // don't use StartDelay() if beginWaveTimer is 0!
            beginWaveTimer -= Time.unscaledDeltaTime; // take away from the begintimer
            timerText.text = beginWaveTimer.ToString("f0"); 
        }
        if(beginWaveTimer <= 0)
        {
            Time.timeScale = originalTimeScale; // restore time scale from before pause
            timerText.gameObject.SetActive(false); 
        }
    }

    public void Reset()
    {
        beginWaveTimer = 5f;
    }
}
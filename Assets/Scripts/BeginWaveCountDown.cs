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
        StartCoroutine("PauseForSeconds");
        Reset();
    }

    private IEnumerator PauseForSeconds()
    {
        float originalTimeScale = Time.timeScale; // store original time scale in case it was not 1
        Time.timeScale = 0; // pause
        while (beginWaveTimer >= 0f)
        {
            yield return null; // don't use WaitForSeconds() if Time.timeScale is 0!
            beginWaveTimer -= Time.unscaledDeltaTime; // returns deltaTime without being multiplied by Time.timeScale
            timerText.text = beginWaveTimer.ToString("f0");
        }
        timerText.gameObject.SetActive(false);
        Time.timeScale = originalTimeScale; // restore time scale from before pause
    }

    public void Reset()
    {
        beginWaveTimer = 5f;
    }
}
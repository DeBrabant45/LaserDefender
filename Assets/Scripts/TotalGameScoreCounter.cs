using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalGameScoreCounter : MonoBehaviour
{
    private Text totalScoreText;

    private void Start()
    {
        totalScoreText = GetComponent<Text>();
    }

    private void Update()
    {
        totalScoreText.text = TotalGameScore.totalScore.ToString();
    }
}

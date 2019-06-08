using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int playerScore = 0;
    const string TOTALSCOREKEY = "Total";
    private Text scoreText;

    void Start ()
    {
        scoreText = GetComponent<Text>();
        //playerScore = PlayerPrefs.GetInt(TOTALSCOREKEY);
        //Reset();
    }
	
	public void Score (int points)
    {
        playerScore += points;
        scoreText.text = playerScore.ToString();
        //PlayerPrefs.SetInt(TOTALSCOREKEY, playerScore);
    }

    public static void Reset ()
    {
        playerScore = 0;
    }

}

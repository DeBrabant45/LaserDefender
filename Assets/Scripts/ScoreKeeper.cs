using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int playerScore = 0;
    private Text scoreText;
    public TotalGameScore game;

    void Start ()
    {
        scoreText = GetComponent<Text>();
        Reset();
    }
	
	public void Score (int points)
    {
        playerScore += points;
        game.GameScore(points);
        scoreText.text = playerScore.ToString();
    }

    public static void Reset ()
    {
        playerScore = 0;
    }

}

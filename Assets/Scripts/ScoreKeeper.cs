using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int playerScore = 0;
    private Text myText;

    void Start ()
    {
       myText = GetComponent<Text>();
        Reset();
    }
	
	public void Score (int points)
    {
        playerScore += points;
        myText.text = playerScore.ToString();
	}
	
    public static void Reset ()
    {
        playerScore = 0;
    }

}

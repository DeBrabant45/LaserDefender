using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalGameScore : MonoBehaviour
{
    public static int totalScore;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GameScore(int points)
    {
        totalScore += points;
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int scoreCount;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextInTotal;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }     
    }

    public void UpdateScore(int score)
    {
        scoreCount += score;
        scoreText.text = scoreCount.ToString();
        scoreTextInTotal.text = scoreCount.ToString();
    }
}

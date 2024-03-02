using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHUD : MonoBehaviour
{
    public static ScoreHUD instance;
    public Text ScoreText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ScoreText.text = "Score: " + GemScript.score.ToString();
    }

    public void IncreaseScore(int increment)
    {
        GemScript.score = GemScript.score + increment;
        ScoreText.text = "Score: " + GemScript.score.ToString();
    }
}
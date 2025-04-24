using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreController : MonoBehaviour
{
    private static ScoreController _instance;
    public static ScoreController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreController>();
            }
            return _instance;
        }
    }
    private TextMeshProUGUI scoreText;
    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        if(scoreText == null)
        {
            Debug.LogError("ScoreController: TextMeshPro component not found.");
        }
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}

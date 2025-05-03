using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathPaneShowScore : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI bestScoreText;

    private void Awake()
    {
        scoreText= transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        if (scoreText == null)
        {
            Debug.LogError("ScoreText not found");
        }
        bestScoreText = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
        if (bestScoreText == null)
        {
            Debug.LogError("BestScoreText not found");
        }
    }
    private void OnEnable()
    {
        ScoreManager.instance.SaveScore();
        scoreText.text = ScoreManager.instance.score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("Record", 0).ToString();
    }
}

using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();
            }
            return _instance;
        }
    }
    [HideInInspector]
    public int score;
    private int lastScore;
    Transform player;
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        lastScore = (int)player.position.x;
        if(lastScore > score)
        {
            score = lastScore;
           ScoreController.Instance.UpdateScore(score);
        }        
    }
    void OnDisable()
    {
        int record = PlayerPrefs.GetInt("Record", 0);
        if (score > record)
        {
            PlayerPrefs.SetInt("Record", score);
            PlayerPrefs.Save();
        }
        Debug.Log("ScoreManager: Score saved to PlayerPrefs: " + PlayerPrefs.GetInt("Record", 0));
    }
}
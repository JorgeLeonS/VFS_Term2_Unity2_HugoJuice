using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI top1Txt, top2Txt, top3Txt;
    private int top1Score, top2Score, top3Score;
    private List<int> topScores = new List<int>();
    void LoadData()
    {
        topScores = new List<int>();

        top1Score = PlayerPrefs.HasKey("Top1") ? PlayerPrefs.GetInt("Top1") : 0;
        top2Score = PlayerPrefs.HasKey("Top2") ? PlayerPrefs.GetInt("Top2") : 0;
        top3Score = PlayerPrefs.HasKey("Top3") ? PlayerPrefs.GetInt("Top3") : 0;

        topScores.Add(top1Score);
        topScores.Add(top2Score);
        topScores.Add(top3Score);

        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            top1Txt.text = top1Score.ToString();
            top2Txt.text = top2Score.ToString();
            top3Txt.text = top3Score.ToString();
        }
    }

    public void CheckIfNewHighScore(int score)
    {
        topScores.Add(score);
        topScores.Sort();
        topScores.Reverse();
        for (int i = 1; i < 4; i++)
        {
            print($"inserting {topScores[i - 1]} on Top{i}");
            PlayerPrefs.SetInt($"Top{i}", topScores[i-1]);
        }
        PlayerPrefs.Save();
    }

    public void ResetHighScore()
    {
        top1Score = 0;
        top2Score = 0;
        top3Score = 0;
        topScores = new List<int>();
        PlayerPrefs.DeleteAll();
        LoadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetHighScore();
        }

    }
}

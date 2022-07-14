using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Sorry for the repeated code, I did it as fast as I could ;(
/// </summary>
public class LoadScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI song1Top1Txt, song1Top2Txt, song1Top3Txt;
    private int song1Top1Score, song1Top2Score, song1Top3Score;
    private List<int> song1TopScores = new List<int>();

    [SerializeField]
    private TextMeshProUGUI song2Top1Txt, song2Top2Txt, song2Top3Txt;
    private int song2Top1Score, song2Top2Score, song2Top3Score;
    private List<int> song2TopScores = new List<int>();

    void Song1LoadData()
    {
        song1TopScores = new List<int>();

        song1Top1Score = PlayerPrefs.HasKey("Song1Top1") ? PlayerPrefs.GetInt("Song1Top1") : 0;
        song1Top2Score = PlayerPrefs.HasKey("Song1Top2") ? PlayerPrefs.GetInt("Song1Top2") : 0;
        song1Top3Score = PlayerPrefs.HasKey("Song1Top3") ? PlayerPrefs.GetInt("Song1Top3") : 0;

        song1TopScores.Add(song1Top1Score);
        song1TopScores.Add(song1Top2Score);
        song1TopScores.Add(song1Top3Score);

        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            song1Top1Txt.text = song1Top1Score.ToString();
            song1Top2Txt.text = song1Top2Score.ToString();
            song1Top3Txt.text = song1Top3Score.ToString();
        }
    }

    void Song2LoadData()
    {
        song2TopScores = new List<int>();

        song2Top1Score = PlayerPrefs.HasKey("Song2Top1") ? PlayerPrefs.GetInt("Song2Top1") : 0;
        song2Top2Score = PlayerPrefs.HasKey("Song2Top2") ? PlayerPrefs.GetInt("Song2Top2") : 0;
        song2Top3Score = PlayerPrefs.HasKey("Song2Top3") ? PlayerPrefs.GetInt("Song2Top3") : 0;

        song2TopScores.Add(song2Top1Score);
        song2TopScores.Add(song2Top2Score);
        song2TopScores.Add(song2Top3Score);

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            song2Top1Txt.text = song2Top1Score.ToString();
            song2Top2Txt.text = song2Top2Score.ToString();
            song2Top3Txt.text = song2Top3Score.ToString();
        }
    }

    public void Song1CheckIfNewHighScore(int score)
    {
        song1TopScores.Add(score);
        song1TopScores.Sort();
        song1TopScores.Reverse();
        for (int i = 1; i < 4; i++)
        {
            //print($"inserting {song1TopScores[i - 1]} on Top{i}");
            PlayerPrefs.SetInt($"Song1Top{i}", song1TopScores[i-1]);
        }
        PlayerPrefs.Save();
    }

    public void Song2CheckIfNewHighScore(int score)
    {
        song2TopScores.Add(score);
        song2TopScores.Sort();
        song2TopScores.Reverse();
        for (int i = 1; i < 4; i++)
        {
            //print($"inserting {song2TopScores[i - 1]} on Top{i}");
            PlayerPrefs.SetInt($"Song2Top{i}", song2TopScores[i - 1]);
        }
        PlayerPrefs.Save();
    }

    public void ResetHighScore()
    {
        song1Top1Score = 0;
        song1Top2Score = 0;
        song1Top3Score = 0;
        song1TopScores = new List<int>();

        song2Top1Score = 0;
        song2Top2Score = 0;
        song2Top3Score = 0;
        song2TopScores = new List<int>();
        PlayerPrefs.DeleteAll();
        Song1LoadData();
        Song2LoadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        Song1LoadData();
        Song2LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    ResetHighScore();
        //}
    }
}

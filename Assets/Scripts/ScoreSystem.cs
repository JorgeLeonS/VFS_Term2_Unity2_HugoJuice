using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScoreNum, ScoreTxt;
    [SerializeField]
    private TextMeshProUGUI comboText;
    [SerializeField]
    private GameObject MenuMango;
    private int scoreCounter;
    public int combo;

    private SceneController sceneController;
    private LoadScore loadScore;

    private Vector3 ScoreNumFinishPosition = new Vector3(-50, -180, -1000);
    private Vector3 ScoreTxtFinishPosition = new Vector3(-41, -130, -1000);

    //UnityEvent songHasFinished;

    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
        loadScore = FindObjectOfType<LoadScore>();
        MenuMango.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Clock.current.event_songHasFinished += LevelFinished;

    }

    // Update is called once per frame
    void Update()
    {
        //if (clock.HasSongFinished())
        //{
        //    LevelFinished();
        //}
    }

    private void LevelFinished()
    {
        StartCoroutine(Cor_LevelFinished());
    }

    private IEnumerator Cor_LevelFinished()
    {
        yield return new WaitForSeconds(5f);
        MenuMango.gameObject.SetActive(true);
        ScoreNum.gameObject.transform.localPosition = ScoreNumFinishPosition;
        ScoreTxt.gameObject.transform.localPosition = ScoreTxtFinishPosition;
        SaveScore();
    }

    public void SaveScore()
    {
        loadScore.CheckIfNewHighScore(ScoreCounter);
    }

    public int ScoreCounter 
    {
        get { return scoreCounter; }
        set 
        { 
            scoreCounter = value;
            ScoreNum.text = $"{value}";
        }
    }

    public int Combo
    {
        get { return combo; }
        set
        {
            combo = value;
            if (combo <= 1)
                comboText.gameObject.SetActive(false);
            else
            {
                comboText.text = $"COMBO X {value}";
                comboText.gameObject.SetActive(true);
            }
        }
    }

    public void ResetCombo()
    {
        Combo = 0;
    }
}

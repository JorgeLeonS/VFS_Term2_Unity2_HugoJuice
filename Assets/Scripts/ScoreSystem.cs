using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private TextMeshProUGUI comboText;
    [SerializeField]
    private TMP_InputField nameInput;
    [SerializeField]
    private Button doneButton;
    private int scoreCounter;
    public int combo;

    //UnityEvent songHasFinished;

    private void Awake()
    {
        //nameInput.gameObject.SetActive(false);
        //doneButton.gameObject.SetActive(false);
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
        yield return new WaitForSeconds(3f);
        doneButton.gameObject.SetActive(true);
        nameInput.gameObject.SetActive(true);
    }

    public void OpenKeyboard()
    {
        print("Open this shit");
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        print("Open this shit2");
    }

    public void SaveScore()
    {
        Debug.Log($"{nameInput.text} score: {ScoreCounter}");
    }

    public int ScoreCounter 
    {
        get { return scoreCounter; }
        set 
        { 
            scoreCounter = value;
            ScoreText.text = $"{value}";
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

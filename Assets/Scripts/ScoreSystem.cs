using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private TextMeshProUGUI comboText;
    private int scoreCounter;
    public int combo;
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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetCombo()
    {
        Combo = 0;
    }
}

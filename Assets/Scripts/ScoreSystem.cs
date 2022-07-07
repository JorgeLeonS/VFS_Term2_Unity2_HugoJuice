using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    private int scoreCounter;
    public int combo;
    public int ScoreCounter 
    {
        get { return scoreCounter; }
        set 
        { 
            scoreCounter = value;
            ScoreText.text = $"Score: {value}";
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
        combo = 0;
        Debug.Log("Combo reseted. Now " + 0);
    }
}

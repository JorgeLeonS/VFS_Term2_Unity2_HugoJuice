using System.Collections;
using UnityEngine;

public class MovingNote : MonoBehaviour
{
    public float Speed;
    public float Life = 1;

    public ScoreSystem scoreSystem;

    private bool hasPassedLimit;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(Life);

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position -= Vector3.forward * Speed * Time.deltaTime;
        if(transform.position.z <= -4 && !hasPassedLimit)
        {
            ResetCombo();
        }
    }

    public void AddPoints()
    {
        scoreSystem.ScoreCounter++;
        scoreSystem.Combo++;
        //Debug.Log("Combo: " + scoreSystem.combo);
    }

    private void ResetCombo()
    {
        scoreSystem.ResetCombo();
        hasPassedLimit = true;
    }
}

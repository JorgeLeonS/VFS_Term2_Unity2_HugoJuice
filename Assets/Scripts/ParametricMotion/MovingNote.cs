using System.Collections;
using UnityEngine;

public class MovingNote : MonoBehaviour
{
    public float Speed;
    public float Life = 1;

    public ScoreSystem scoreSystem;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(Life);

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position -= Vector3.forward * Speed * Time.deltaTime;
    }

    public void AddPoints()
    {
        scoreSystem.ScoreCounter++;
    }
}

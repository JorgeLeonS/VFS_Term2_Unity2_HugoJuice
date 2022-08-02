using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    private Vector3 spawningPos;

    public GameObject[] prefabsToSpawn;
    public float timeStart = 0;
    public float frequency = 0;
    public bool moveRight = false;
    public bool moveLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObj", timeStart, frequency);
        spawningPos = this.transform.position;
        spawningPos.y = 0.2f;
    }

    private void spawnObj()
    {
        GameObject pref = null;
        int prefabToSPawn = (int)Random.Range(0.0f, prefabsToSpawn.Length);
        if (moveLeft)
        {
            pref = Instantiate(prefabsToSpawn[prefabToSPawn], spawningPos, Quaternion.Euler(0, -90, 0)) as GameObject;
            pref.transform.parent = GameObject.Find("--SCENE--").transform;
            //pref.transform.rotation = Quaternion.Euler(0, -90, 0);
            pref.GetComponent<MovePrefab>().moveL = true;
        }
        else if(moveRight)
        {
            pref = Instantiate(prefabsToSpawn[prefabToSPawn], spawningPos, Quaternion.Euler(0, 90, 0)) as GameObject;
            pref.transform.parent = GameObject.Find("--SCENE--").transform;
            //pref.transform.rotation = Quaternion.Euler(0, 90, 0);
            pref.GetComponent<MovePrefab>().moveR = true;
        }
    }
}

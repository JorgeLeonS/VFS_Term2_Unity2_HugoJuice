
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePrefab : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed;

    // Variables used to determine the direction of the prefab
    public bool moveR = false;
    public bool moveL = false;

    // Game Objects that work as target
    private GameObject rightWall;
    private GameObject leftWall;

    // Vector that will store the position of the target
    private Vector3 targetPos;

    private void Awake()
    {
        rightWall = GameObject.FindGameObjectWithTag("RightObjective");
        leftWall = GameObject.FindGameObjectWithTag("LeftObjective");
    }

    // Update is called once per frame
    void Update()
    {

        // Decides the movement based on the value of moveR and moveL
        if (moveR)
        {
            targetPos = new Vector3(rightWall.transform.position.x, 0.0f, rightWall.transform.position.z);
            //rotate(rightWall);
            move();
        }
        else if (moveL)
        {
            targetPos = new Vector3(leftWall.transform.position.x, 0.0f, leftWall.transform.position.z);
            //rotate(leftWall);
            move();
        }
    }

    void rotate(GameObject target)
    {
        float yRoation = target.transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRoation, transform.eulerAngles.z);
    }

    void move()
    {
        var step = speed * Time.deltaTime;

        // Checking if the object has reached the target
        if (transform.position != targetPos)
        {             
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }
        else
        {
           // Once the object has reached the target it is removed from the scene
           Destroy(gameObject);
        }
    }

    // Function to check if the object has collided with the player
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.rotation = Quaternion.identity;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

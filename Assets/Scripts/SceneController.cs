using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneWithDelay(string scene, float waitSeconds)
    {
        object[] parms = new object[2] { scene, waitSeconds };
        StartCoroutine("LoadLevel", parms);
    }

    IEnumerator LoadLevel(object[] parms)
    {
        string scene = (string)parms[0];
        float transitionTime = (float)parms[1];

        yield return new WaitForSeconds(transitionTime);
        Debug.Log("Changing to scene: " + scene);
        SceneManager.LoadScene(scene);
    }
}

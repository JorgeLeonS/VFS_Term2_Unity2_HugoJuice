using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneWithDelay(string scene, Animator transition, float waitSeconds = 1)
    {
        object[] parms = new object[3] {scene, transition, waitSeconds};
        StartCoroutine("LoadLevel", parms);
    }
    public void ReturnToMainMenu(float transitionTime)
    {
        StartCoroutine("LoadMainMenu", transitionTime);
    }

    public void RestartLevel(float transitionTime)
    {
        StartCoroutine("ReloadLevel", transitionTime);
    }

    IEnumerator LoadLevel(object[] parms)
    {
        string scene = (string)parms[0];
        Animator transition = (Animator)parms[1];
        float transitionTime = (float)parms[2];

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("Changing to scene: " + scene);
        SceneManager.LoadScene(scene);
    }

    IEnumerator LoadMainMenu(float transitionTime)
    {
        Debug.Log("Loading Main Menu scene");
        Time.timeScale = 1;

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator ReloadLevel(float transitionTime)
    {
        Debug.Log("Reloading scene");
        Time.timeScale = 1;

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

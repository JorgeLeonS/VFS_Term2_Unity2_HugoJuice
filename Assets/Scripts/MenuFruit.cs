using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFruit : MonoBehaviour
{
    public string scene;
    public float transitionTime = 1;
    public SceneController sceneManager;
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = FindObjectOfType<SceneController>();
    }
    void Update()
    {
    }

    public void GoToScene()
    {
        sceneManager.LoadSceneWithDelay(scene, transition, transitionTime);
    }
}

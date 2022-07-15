using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuSpawn : MonoBehaviour
{
    [SerializeField] InputActionAsset playerControls;
    [SerializeField] GameObject handMenu;
    [SerializeField] Clock clock;
    bool showMenu = false;
    InputAction displayMenu;

    // Start is called before the first frame update
    void Start()
    {
        var gameplayActionMap = playerControls.FindActionMap("Default");
        displayMenu = gameplayActionMap.FindAction("ShowMenu");

        displayMenu.performed += OnMenuBtnPressed;
        displayMenu.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        handMenu.SetActive(showMenu);
    }

    public void OnMenuBtnPressed(InputAction.CallbackContext context)
    {
        showMenu = !showMenu;
        if (showMenu)
        {
            PauseLevel();
        }
        else
            Resume();
    }

    public void PauseLevel()
    {
        Time.timeScale = 0;
        clock.pauseSong();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        clock.continueSong();
    }
}
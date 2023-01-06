using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    private void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void GoToMainMenu()
    {
        // Make sure MainMenu is the 1st scene in build setrtings and has index 0
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene(0);
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("You quit the game!");
    }
}

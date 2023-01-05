using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (GamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void GoToMainMenu()
    {
        // Make sure MainMenu is the 1st scene in build setrtings and has index 0
        Time.timeScale = 1f;
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene(0);
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("You quit the game!");
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        GamePaused = false;
        Time.timeScale = 1f;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        GamePaused = true;
    }
}

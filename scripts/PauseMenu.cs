using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused;
    public GameObject pauseMenuUI;
    public GameObject ControlPanel;
    public GameObject healthBar;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        ControlPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GamePaused = false;
        healthBar.SetActive(true);
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GamePaused = true;
        healthBar.SetActive(false);

    }
    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
    public void Controls()
    {
        Time.timeScale = 0f;
        ControlPanel.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    
}

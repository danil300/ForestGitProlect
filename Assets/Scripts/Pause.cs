using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool IsPause;

    public void Start()
    {
        PauseMenu.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause)
            {
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                PauseGame();
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void PauseGame()
    {
        IsPause = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        IsPause = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitAtMenu()
    {
        SceneManager.LoadScene("mainmene");
    }
}

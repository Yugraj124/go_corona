using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenu;
    public GameObject player;

    private void Update()
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

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        player.GetComponent<MouseLooker>().enabled = false;
        GamePaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<MouseLooker>().enabled = true;
        GamePaused = false;
    }

    public void loadScene(string sceneToLoad)
    {
        Resume();
        SceneManager.LoadScene(sceneToLoad);
    }
}

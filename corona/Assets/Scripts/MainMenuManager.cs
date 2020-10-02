using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	public Button QuitButton;

    private void Awake()
    {
		displayExitButton();
    }

	void displayExitButton()
	{
		switch (Application.platform)
		{
			case RuntimePlatform.WindowsPlayer:
			case RuntimePlatform.OSXPlayer:
			case RuntimePlatform.LinuxPlayer:
				QuitButton.interactable = true;
				break;
			default:
				QuitButton.interactable = false;
				break;
		}
	}

	public void loadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}

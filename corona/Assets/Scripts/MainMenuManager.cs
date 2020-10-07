using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	public Button QuitButton;
    public Animator transition;
    public float transitionTime = 1f;

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
        StartCoroutine(LoadLevel(sceneToLoad));
    }

    IEnumerator LoadLevel(string levelToLoad)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelToLoad);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}

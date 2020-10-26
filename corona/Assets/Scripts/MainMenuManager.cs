using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject instructions;
    public GameObject mainMenu;
	public Button QuitButton;
    public Animator transition;
    public float transitionTime = 1f;

    bool onInstructions = false;

    private void Awake()
    {
		displayExitButton();
    }

    public void toggleInstructions()
    {
        if (!onInstructions)
        {
            mainMenu.SetActive(false);
            instructions.SetActive(true);
            onInstructions = true;
        }
        else
        {
            instructions.SetActive(false);
            mainMenu.SetActive(true);
            onInstructions = false;
        }
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

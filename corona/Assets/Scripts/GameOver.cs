using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public bool PlayerDead = false;
    public GameObject endScreen;
    public GameObject player;
    public Animator transition;
    public float transitionTime = 1f;

    private void Update()
    {
        if (PlayerDead)
        {
            endScreen.SetActive(true);
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
}

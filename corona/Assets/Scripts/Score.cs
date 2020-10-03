using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    int score = 0;
    public GameManager gameManager;
    private void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.text = score.ToString();
    }
    public void ScoreAdd()
    {
        score += 1;
        if (score > 0 && score%5 == 0)
        {
            gameManager.scoreChanged();
        }
        text.text = score.ToString();
    }
}

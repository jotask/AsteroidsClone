using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{

    public Text scoreText;

    private void Start()
    {
        GameManager.Instance.scoreManager.ScoreUpdated += ScoreUpdated;
    }

    public void ScoreUpdated(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }

}

using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{

    public Text scoreText;

    private void Start()
    {
        // Subscribe to the score updated event, we will get notify when the score has been updated.
        GameManager.Instance.scoreManager.ScoreUpdated += ScoreUpdated;
    }

    public void ScoreUpdated(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }

}

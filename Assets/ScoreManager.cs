using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public delegate void ListenToScoreUpdates(int updateScore);
    public ListenToScoreUpdates ScoreUpdated;

    private int currentScore;

    private void Start()
    {
        currentScore = 0;
    }

    public void AddToScore(int point)
    {
        currentScore += point;
        if (ScoreUpdated != null)
        {
            ScoreUpdated(currentScore);
        }
    }

}

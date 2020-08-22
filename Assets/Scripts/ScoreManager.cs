using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    // Delegates so UI component can subscribe to this events. They will get notify with the new score when has been updated.
    public delegate void ListenToScoreUpdates(int updateScore);
    public ListenToScoreUpdates ScoreUpdated;

    // Our current score
    private int currentScore;

    private void Start()
    {
        currentScore = 0;
    }

    public void AddToScore(int point)
    {
        currentScore += point;
        // Notify all delegates subscribed if they are any.
        if (ScoreUpdated != null)
        {
            ScoreUpdated(currentScore);
        }
    }

}

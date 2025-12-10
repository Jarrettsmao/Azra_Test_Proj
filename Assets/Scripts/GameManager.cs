using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int scoreToWin;
    // [SerializeField] private Player player;
    void Start()
    {
        ScoreManager.Instance.OnScoreChanged.AddListener(CheckWin);
    }

    void CheckWin(int currentScore)
    {   
        if (currentScore >= scoreToWin)
        {
            EndGame(true);
        }
    }

    void EndGame(bool won)
    {
        Time.timeScale = 0;
        Debug.Log("Win " + won);
    }
}

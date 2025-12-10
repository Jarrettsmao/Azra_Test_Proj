using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int scoreToWin;
    [SerializeField] private EndGameUI endGameUI;
    void Start()
    {
        ScoreManager.Instance.OnScoreChanged.AddListener(CheckScore);
        PlayerHealthManager.Instance.OnHealthChanged.AddListener(CheckHealth);
    }

    private void CheckScore(int currentScore)
    {
        if (currentScore >= scoreToWin)
        {
            EndGame(true); // player wins
        }
    }

    private void CheckHealth(int currentHealth)
    {
        if (currentHealth <= 0)
        {
            EndGame(false); // player loses
        }
    }

    void EndGame(bool won)
    {
        endGameUI.ShowEndGame(won);
        Time.timeScale = 0;
    }
}

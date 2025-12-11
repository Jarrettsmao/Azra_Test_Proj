using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EndGameUI endGameUI;
    [SerializeField] private int scoreToWin;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-find the EndGameUI in the newly loaded scene
        endGameUI = FindObjectOfType<EndGameUI>();

        // Re-subscribe to events
        ScoreManager.Instance.OnScoreChanged.AddListener(CheckScore);
        PlayerHealthManager.Instance.OnHealthChanged.AddListener(CheckHealth);
    }

    private void CheckScore(int currentScore)
    {
        if (currentScore >= scoreToWin) EndGame(true);
    }

    private void CheckHealth(int currentHealth)
    {
        if (currentHealth <= 0) EndGame(false);
    }

    private void EndGame(bool won)
    {
        if (endGameUI != null) endGameUI.ShowEndGame(won);
        Time.timeScale = 0;
    }
}

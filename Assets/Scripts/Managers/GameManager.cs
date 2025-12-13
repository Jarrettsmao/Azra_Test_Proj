using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private EndGameUI endGameUI;
    [SerializeField] private int scoreToWin;

    private void Awake()
    {
        Instance = this;
    }

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
        // get the endgameUI on reload
        endGameUI = FindFirstObjectByType<EndGameUI>();

        // get events on reload
        ScoreManager.Instance.OnScoreChanged.AddListener(CheckScore);
        PlayerHealthManager.Instance.OnHealthChanged.AddListener(CheckHealth);
    }

    private void CheckScore(int currentScore)
    {
        if (currentScore >= scoreToWin)
        {
            EndGame(true);
        }
    }

    private void CheckHealth(int currentHealth)
    {
        if (currentHealth <= 0)
        {
            EndGame(false);
        }
    }

    private void EndGame(bool won)
    {
        if (endGameUI != null)
        {
            endGameUI.ShowEndGame(won);
        }
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        StopAllCoroutines();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int GetScoreToWin() => scoreToWin;
}

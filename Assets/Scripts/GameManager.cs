using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int scoreToWin;
    // [SerializeField] private Player player;
    void Start()
    {
        ScoreManager.Instance.OnScoreChanged.AddListener(CheckWin);
        PlayerHealthManager.Instance.OnHealthChanged.AddListener(CheckWin);
    }

    void CheckWin(int currentScore)
    {   
        if (currentScore >= scoreToWin)
        {
            EndGame(true);
        } else if (currentScore <= 0)
        {
            EndGame(false);
        }
    }

    void EndGame(bool won)
    {
        Time.timeScale = 0;
        Debug.Log("Win " + won);
    }
}

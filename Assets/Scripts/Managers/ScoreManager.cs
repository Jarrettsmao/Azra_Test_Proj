using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public UnityEvent<int> OnScoreChanged = new UnityEvent<int>();

    private int score = 0;

    void Awake()
    {
        Instance = this;

        if (OnScoreChanged == null)
            OnScoreChanged = new UnityEvent<int>();
    }

    void Start()
    {
        //make the initial score show
        OnScoreChanged.Invoke(score);
    }

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged.Invoke(score);
    }

    public int GetScore() => score;
}

using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public UnityEvent<int> OnScoreChanged = new UnityEvent<int>();
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    void Awake()
    {
        Instance = this;

        if (OnScoreChanged == null){
            OnScoreChanged = new UnityEvent<int>();
        }
        OnScoreChanged.AddListener(UpdateScoreUI);
    }

    void Start()
    {
        //make the zero appear
        UpdateScoreUI(score); 
    }

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged.Invoke(score);
    }

    private void UpdateScoreUI(int newScore)
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public int GetScore() => score;

}

using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        ScoreManager.Instance.OnScoreChanged.AddListener(UpdateUI);
        UpdateUI(ScoreManager.Instance.GetScore());
    }

    private void UpdateUI(int score)
    {
        scoreText.text = $"{score} / {GameManager.Instance.GetScoreToWin()}";
    }
}

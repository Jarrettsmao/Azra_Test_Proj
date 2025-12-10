using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class EndGameUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI endGameText;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        panel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    public void ShowEndGame(bool victory)
    {
        panel.SetActive(true);
        endGameText.text = victory ? "Victory!" : "Defeat!";
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}

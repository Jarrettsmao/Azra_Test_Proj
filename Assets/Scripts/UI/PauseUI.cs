using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button restartButton;
    [SerializeField] private EndGameUI endGameUI;

    private bool isPaused = false;

    private void Awake()
    {
        panel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !endGameUI.IsPanelActive())
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        panel.SetActive(true);

        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        isPaused = false;
        panel.SetActive(false);

        Time.timeScale = 1f;
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

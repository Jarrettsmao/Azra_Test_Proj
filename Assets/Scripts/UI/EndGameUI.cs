using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI endGameText;
    [SerializeField] private Button restartButton;
    [SerializeField] private TMP_Dropdown difficultyDropdown;
    [SerializeField] private List<DifficultyData> difficultyOptions;

    private void Awake()
    {
        panel.SetActive(false);

        restartButton.onClick.AddListener(RestartGame);
        difficultyDropdown.onValueChanged.AddListener(OnDifficultyChanged);
        // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeDropdown();
    }

    private void InitializeDropdown()
    {
        difficultyDropdown.ClearOptions();

        List<string> names = new List<string>();
        foreach (var diff in difficultyOptions)
        {
            names.Add(diff.difficultyName);
        }

        difficultyDropdown.AddOptions(names);

        // Select current difficulty
        int index = difficultyOptions.IndexOf(DifficultyController.Instance.Current);
        difficultyDropdown.value = index;
    }

    public void ShowEndGame(bool victory)
    {
        panel.SetActive(true);
        endGameText.text = victory ? "Victory!" : "Defeat!";
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panel.SetActive(false);
    }

    private void OnDifficultyChanged(int index)
    {
        DifficultyController.Instance.SetDifficulty(difficultyOptions[index]);
        Debug.Log("Difficulty changed to: " + difficultyOptions[index].difficultyName);
    }
}

using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public static DifficultyController Instance { get; private set; }
    [SerializeField] private DifficultyData difficulty;
    public DifficultyData Current => difficulty;

    private void Awake()
    {
        //prevent duplicates and allow for easy to be the default on first load
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void SetDifficulty(DifficultyData newDifficulty)
    {
        difficulty = newDifficulty;
    }
}

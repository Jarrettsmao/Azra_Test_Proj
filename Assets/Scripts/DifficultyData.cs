using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "Game/Difficulty")]
public class DifficultyData : ScriptableObject
{
    public string difficultyName;
    public float enemySpeedMultiplier = 1f;
    public int enemyCount = 3;
    public int hunterCount = 1;
    public float spawnRate = 2f;
}

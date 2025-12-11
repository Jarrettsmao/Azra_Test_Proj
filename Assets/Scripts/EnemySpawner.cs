using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject hunterPrefab;
    [SerializeField] private float launchForceMin = 10f;
    [SerializeField] private float launchForceMax = 20f;
    private float numEnemies;
    private float numHunters;
    private float spawnDelay;
    void Start()
    {
        var difficulty = DifficultyController.Instance.Current;
        spawnDelay = difficulty.spawnRate;
        numEnemies = difficulty.enemyCount;
        numHunters = difficulty.hunterCount;

        StartCoroutine(SpawnEnemiesWithDelay());
    }

    private IEnumerator SpawnEnemiesWithDelay()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
        for (int i = 0; i < numHunters; i++)
        {
            SpawnHunter();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        
        //launch in a random direction
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        float randomForce = Random.Range(launchForceMin, launchForceMax);
        rb.AddForce(randomDir * randomForce, ForceMode2D.Impulse);
    }

    public void SpawnHunter()
    {
        GameObject hunter = Instantiate(hunterPrefab, transform.position, Quaternion.identity);
    }
}

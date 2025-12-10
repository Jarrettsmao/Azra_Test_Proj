using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject hunterPrefab;
    [SerializeField] private float launchForceMin = 10f;
    [SerializeField] private float launchForceMax = 20f;
    [SerializeField] private float numEnemies;
    [SerializeField] private float spawnDelay = 1f;
    void Start()
    {
        StartCoroutine(SpawnEnemiesWithDelay());
    }

    private IEnumerator SpawnEnemiesWithDelay()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
        SpawnHunter();
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

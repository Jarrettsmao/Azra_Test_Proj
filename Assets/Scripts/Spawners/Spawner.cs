using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject spawnTarget;

    protected GameObject SpawnObject(GameObject spawnTarget)
    {
        return Instantiate(spawnTarget, transform.position, Quaternion.identity);
    }
}

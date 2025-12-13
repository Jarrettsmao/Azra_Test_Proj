using UnityEngine;

public class PlayerSpawner : Spawner
{
    void Start()
    {
        Camera.main.GetComponent<CameraFollow>().target = SpawnObject(spawnTarget);;
    }
}

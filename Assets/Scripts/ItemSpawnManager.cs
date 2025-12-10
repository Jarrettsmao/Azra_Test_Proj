using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public GameObject itemPrefab;
    [SerializeField] private GameObject leftBorder, rightBorder, topBorder, botBorder;
    private float leftX, rightX, botY, topY;
    [SerializeField] private float numItems = 10f;
    [SerializeField] private LayerMask layerMask;

    void Start()
    {
        layerMask = LayerMask.GetMask("Player", "BouncePad", "Borders", "Items");

        leftX = leftBorder.transform.position.x;
        rightX = rightBorder.transform.position.x;
        botY = botBorder.transform.position.y;
        topY = topBorder.transform.position.y;

        for (int i = 0; i < numItems; i++)
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        Vector2 spawnPos = GetRandomSpawnPosition();

        //check for overlapping objs
        Collider2D hit = Physics2D.OverlapCircle(spawnPos, 0.5f, layerMask);

        if (!hit)
        {
            Instantiate(itemPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            SpawnItem();
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        float x = Random.Range(leftX, rightX);
        float y = Random.Range(botY, topY);

        return new Vector2(x, y);
    }
}

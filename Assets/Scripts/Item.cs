using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] public int scoreVal = 1;
    // public UnityEvent OnCollected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Increase score through scoremanager
        if (collision.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(scoreVal);
            Destroy(gameObject);
        }

    }
}

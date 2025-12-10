using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int damage = -1;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealthManager.Instance.ChangeHealth(damage);
            Destroy(gameObject);
        }
    }
}

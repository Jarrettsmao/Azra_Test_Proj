using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move in current direction at constant speed
        rb.linearVelocity = rb.linearVelocity.normalized * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Border"))
        {
            Vector2 normal = collision.contacts[0].normal;

            // Reflect the velocity based on collision normal and add a slight random angle
            Vector2 newDirection = Vector2.Reflect(rb.linearVelocity.normalized, normal);

            // Add small random variation so enemies don't go perfectly straight
            float randomAngle = Random.Range(-30f, 30f);
            newDirection = Quaternion.Euler(0, 0, randomAngle) * newDirection;

            rb.linearVelocity = newDirection.normalized * moveSpeed;
        }
    }
}
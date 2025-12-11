using UnityEngine;

public class HunterMovement : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 2f;
    [SerializeField] private float maxSpeed = 4f;
    [SerializeField] private float rotateSpeed = 10f;
    private float moveSpeed;

    private Transform player;
    private Rigidbody2D rb;
    public bool movementDisabled;
    private Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movementDisabled = false;
        moveSpeed = baseSpeed * DifficultyController.Instance.Current.enemySpeedMultiplier;
    }

    void FixedUpdate()
    {
        //face towards player
        // direction = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRot = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotateSpeed * Time.fixedDeltaTime);

        if (movementDisabled)
        {
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
        else
        {
            if (rb.linearVelocity.magnitude > moveSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * moveSpeed;
            }
        }

    }

    void Update()
    {
        huntPlayer();
    }

    private void huntPlayer()
    {
        direction = (player.position - transform.position).normalized;
        if (movementDisabled == false)
        {
            rb.AddForce(direction * moveSpeed);
        }

    }
}

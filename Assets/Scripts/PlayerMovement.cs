using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxBoostSpeed;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    public bool isBoosted = false;
    public bool controlsDisabled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!controlsDisabled)
        {
            InputControls();
        }
    }
    void FixedUpdate()
    {
        //cap speed when not boosted
        if (!isBoosted)
        {
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
        else
        {
            if (rb.linearVelocity.magnitude > maxBoostSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxBoostSpeed;
            }
        }
    }

    private void InputControls()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        moveInput = new Vector2(x, y).normalized;

        if (moveInput.sqrMagnitude > 0.01f)
        {
            Vector2 forceToApply = moveInput * moveForce;
            rb.AddForce(forceToApply);
        }
    }


}

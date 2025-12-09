using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce;
    [SerializeField] private float boostDuration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float boostMultiplier;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveInput;
    private bool isBoosted = false;
    private bool controlsDisabled = false;
    private Color originalColor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
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
        //cap speed
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BouncePad"))
        {
            StartCoroutine(ApplySpeedBoost());
        }
    }

    private IEnumerator ApplySpeedBoost()
    {

        isBoosted = true;
        controlsDisabled = true;
        sr.color = new Color(255f/255f, 0f, 0f);

        yield return new WaitForSeconds(boostDuration);

        isBoosted = false;
        controlsDisabled = false;
        sr.color = originalColor;
    }

    private void InputControls()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        moveInput = new Vector2(x, y).normalized;

        if (moveInput.sqrMagnitude > 0.01f)
        {
            Vector2 forceToApply = moveInput * moveForce;

            if (isBoosted)
            {
                forceToApply *= boostMultiplier;
            }
            rb.AddForce(forceToApply);
        }
    }
}

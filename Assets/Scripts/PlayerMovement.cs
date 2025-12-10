using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce;
    [SerializeField] private float boostDuration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxBoostSpeed;
    [SerializeField] private float boostMultiplier;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveInput;
    private bool isBoosted = false;
    private bool controlsDisabled = false;
    private Color originalColor;
    private Coroutine activeColorCoroutine;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BouncePad"))
        {
            CheckActiveCoroutine(ApplySpeedBoost());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            CheckActiveCoroutine(FlashCollected());
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

    private IEnumerator ApplySpeedBoost()
    {
        //overrides color if there is another coroutine

        isBoosted = true;
        controlsDisabled = true;
        sr.color = new Color(255f / 255f, 0f, 0f);

        yield return new WaitForSeconds(boostDuration);

        isBoosted = false;
        controlsDisabled = false;
        sr.color = originalColor;
        activeColorCoroutine = null;
    }

    private IEnumerator FlashCollected()
    {
        sr.color = new Color(0f, 255f / 255f, 0f);

        yield return new WaitForSeconds(0.25f);

        sr.color = originalColor;
        activeColorCoroutine = null;
    }

    private void CheckActiveCoroutine(IEnumerator coroutine)
    {
        if (activeColorCoroutine != null)
        {
            StopCoroutine(activeColorCoroutine);
        }
        activeColorCoroutine = StartCoroutine(coroutine);
    }
}

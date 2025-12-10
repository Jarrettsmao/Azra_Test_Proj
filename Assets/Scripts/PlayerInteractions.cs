using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerInteractions : MonoBehaviour
{
    private Coroutine activeColorCoroutine;
    private Color originalColor;
    private PlayerMovement playerMovement;
    private SpriteRenderer sr;
    [SerializeField] private float boostDuration = 1f;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
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
    private IEnumerator ApplySpeedBoost()
    {
        playerMovement.isBoosted = true;
        sr.color = new Color(255f / 255f, 0f, 0f);
        StartCoroutine(DisableControls());

        yield return new WaitForSeconds(boostDuration);

        playerMovement.isBoosted = false;
        sr.color = originalColor;
        activeColorCoroutine = null;
    }

    private IEnumerator FlashCollected()
    {
        sr.color = new Color(255f/255f, 252f/255f, 165f/255f);

        yield return new WaitForSeconds(0.25f);

        sr.color = originalColor;
        activeColorCoroutine = null;
    }

    private IEnumerator DisableControls()
    {
        playerMovement.controlsDisabled = true;
        yield return new WaitForSeconds(boostDuration);
        playerMovement.controlsDisabled = false;
    }

    //overrides color if there is another coroutine
    private void CheckActiveCoroutine(IEnumerator coroutine)
    {
        if (activeColorCoroutine != null)
        {
            StopCoroutine(activeColorCoroutine);
        }
        activeColorCoroutine = StartCoroutine(coroutine);
    }
}

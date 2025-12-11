using UnityEngine;
using System.Collections;

public class PlayerInteractions : Bounceable
{
    private PlayerMovement playerMovement;
    [SerializeField] private float boostDuration = 1f;
    [SerializeField] private float flashDuration = 0.25f;

    protected override void Awake()
    {
        base.Awake();
        playerMovement = GetComponent<PlayerMovement>();
    }

    protected override IEnumerator OnBouncePadCollision(Collision2D collision)
    {
        playerMovement.isBoosted = true;
        StartCoroutine(DisableControls());
        yield return FlashColor(Color.red, boostDuration);
        playerMovement.isBoosted = false;
    }

    private IEnumerator DisableControls()
    {
        playerMovement.controlsDisabled = true;
        yield return new WaitForSeconds(boostDuration);
        playerMovement.controlsDisabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Item"))
        {
            if (activeCoroutine != null)
            {
                StopCoroutine(activeCoroutine);
            }
            activeCoroutine = StartCoroutine(FlashColor(
                new Color(255f / 255f, 252f / 255f, 165f / 255f),
                flashDuration
            ));
        }
    }

}

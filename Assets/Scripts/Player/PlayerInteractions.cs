using UnityEngine;
using System.Collections;

public class PlayerInteractions : Bounceable
{
    private PlayerMovement playerMovement;
    [SerializeField] private float boostDuration = 1f;

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
}

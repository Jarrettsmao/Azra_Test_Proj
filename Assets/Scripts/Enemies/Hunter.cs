using UnityEngine;
using System.Collections;

public class Hunter : Bounceable
{
    private HunterMovement hunterMovement;
    [SerializeField] private float disableDuration = 1f;

    protected override void Awake()
    {
        base.Awake();
        hunterMovement = GetComponent<HunterMovement>();
    }

    protected override IEnumerator OnBouncePadCollision(Collision2D collision)
    {
        hunterMovement.movementDisabled = true;
        yield return FlashColor(Color.red, disableDuration);
        hunterMovement.movementDisabled = false;
    }
}

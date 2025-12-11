using UnityEngine;
using System.Collections;

public class PlayerInteractions : Bounceable
{
    private PlayerMovement playerMovement;
    [SerializeField] private float boostDuration = 1f;
    [SerializeField] private float flashDuration = 0.25f;
    private bool isInvincible = false;
    private int playerLayer;
    private int enemyLayer;

    protected override void Awake()
    {
        base.Awake();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        PlayerHealthManager.Instance.OnHealthChanged.AddListener(OnPlayerHit);
        playerLayer = 6;
        enemyLayer = 10;
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

    private void OnPlayerHit(int currentHealth)
    {
        if (!isInvincible)
        {
            StartCoroutine(StartInvincibility());
        }
    }

    private IEnumerator StartInvincibility()
    {
        isInvincible = true;
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.3f);
            
        yield return new WaitForSeconds(DifficultyController.Instance.Current.invincibilityTime);

        isInvincible = false;
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        sr.color = originalColor;
    }

}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Bounceable : MonoBehaviour
{
    protected SpriteRenderer sr;
    protected Color originalColor;
    protected Coroutine activeCoroutine;

    [SerializeField] protected float highlightDuration = 0.25f;

    protected virtual void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BouncePad"))
        {
            if (activeCoroutine != null)
                StopCoroutine(activeCoroutine);

            activeCoroutine = StartCoroutine(OnBouncePadCollision(collision));
        }
    }

    protected abstract IEnumerator OnBouncePadCollision(Collision2D collision);

    protected IEnumerator FlashColor(Color flashColor, float duration)
    {
        sr.color = flashColor;
        yield return new WaitForSeconds(duration);
        sr.color = originalColor;
        activeCoroutine = null;
    }
}

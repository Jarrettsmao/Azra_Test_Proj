using UnityEngine;
using System.Collections;

public class Hunter : Enemy
{
    private HunterMovement hunterMovement;
    private SpriteRenderer sr;
    private Color originalColor;
    private bool activeCoroutine = false;
    [SerializeField] private float disableDuration = 1f;

    void Start()
    {
        hunterMovement = GetComponent<HunterMovement>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision); //calls player collision

        if (collision.collider.CompareTag("BouncePad"))
        {
            if (activeCoroutine)
            {
                StopCoroutine(DisableMovement());
            }
            StartCoroutine(DisableMovement());
        }
    }

    private IEnumerator DisableMovement()
    {
        activeCoroutine = true;
        hunterMovement.movementDisabled = true;
        sr.color = new Color(255f / 255f, 0f, 0f);
        
        yield return new WaitForSeconds(disableDuration);
        
        activeCoroutine = false;
        hunterMovement.movementDisabled = false;
        sr.color = originalColor;
        
    }
}

using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]  
public class BouncePad : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    [SerializeField] private float highlightDuration;
    private Color originalColor;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        // get contact point
        ContactPoint2D contact = collision.contacts[0];
        Vector2 normal = contact.normal;

        Vector2 incomingVelocity = rb.linearVelocity;
        Vector2 reflectDirection = Vector2.Reflect(incomingVelocity, normal);

        float speed = incomingVelocity.magnitude;

        // apply force in the opposite direction of the contact normal
        rb.AddForce(reflectDirection * bounceForce, ForceMode2D.Impulse);

        StartCoroutine(ChangeColor());

    }

    private IEnumerator ChangeColor()
    {
        sr.color = new Color(255f / 255f, 0f, 0f);
        yield return new WaitForSeconds(highlightDuration);
        sr.color = originalColor;
    }
}

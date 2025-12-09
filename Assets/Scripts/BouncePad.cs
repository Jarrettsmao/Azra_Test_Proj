using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private float bounceForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        if (rb)
        {
            // get contact point
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;

            Vector2 incomingVelocity = rb.linearVelocity;
            Vector2 reflectDirection = Vector2.Reflect(incomingVelocity, normal);

            float speed = incomingVelocity.magnitude;

            // apply force in the opposite direction of the contact normal
            rb.AddForce(reflectDirection * Mathf.Max(speed, bounceForce), ForceMode2D.Impulse);
        }

    }
}

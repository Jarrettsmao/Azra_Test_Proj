using UnityEngine;
using System.Collections;

public class Hunter : Enemy
{
    private HunterMovement hunterMovement;
    [SerializeField] private float disableDuration = 1f;

    void Start()
    {
        hunterMovement = GetComponent<HunterMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision); //calls player collision

        if (collision.collider.CompareTag("BouncePad"))
        {
            StartCoroutine(DisableMovement());
        }
    }

    private IEnumerator DisableMovement()
    {
        hunterMovement.movementDisabled = true;
        Debug.Log("disabled");
        yield return new WaitForSeconds(disableDuration);
        hunterMovement.movementDisabled = false;
        Debug.Log("enabled");
    }
}

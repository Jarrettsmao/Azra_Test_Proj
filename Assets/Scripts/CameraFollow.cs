using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float interpVelocity;
    [SerializeField] private float speed;
    public GameObject target;
    [SerializeField] private Vector3 offset;
    private Vector3 targetPos;
    void Start()
    {
        targetPos = transform.position;
    }

    void FixedUpdate()
    {
        if (target)
        {
            //makes camera align with the target on z axis
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * speed;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);
        }
    }
}

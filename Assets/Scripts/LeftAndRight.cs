using UnityEngine;

/**
 * This component moves its object back and forth between two points in space, using a Rigidbody.
 */
[RequireComponent(typeof(Rigidbody))]
public class LeftAndRight : MonoBehaviour
{
    [Tooltip("The points between which the platform moves")]
    [SerializeField] private Transform startPoint = null, endPoint = null;

    [SerializeField] private float speed = 1f;

    private bool moveFromStartToEnd = true;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (moveFromStartToEnd)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime));
        }
        else
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime));
        }

        if (transform.position == startPoint.position)
        {
            moveFromStartToEnd = true;
        }
        else if (transform.position == endPoint.position)
        {
            moveFromStartToEnd = false;
        }
    }
}

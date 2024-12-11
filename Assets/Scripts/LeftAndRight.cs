// using UnityEngine;

// public class LeftAndRight : MonoBehaviour
// {
//     // Move the platform left and right

//     [SerializeField] private float speed = 1;
//     [SerializeField] private float MaxLeft = -5;
//     [SerializeField] private float MaxRight = 5;

//     private void Update()
//     {
//         // Move the platform left and right
//         transform.position += Vector3.right * speed * Time.deltaTime;

//         if (transform.position.x >= MaxRight)
//         {
//             speed = -Mathf.Abs(speed);
//         }
//         else if (transform.position.x <= MaxLeft)
//         {
//             speed = Mathf.Abs(speed);
//         }
//     }
// }

using UnityEngine;

/**
 *  This component moves its object back and forth between two points in space, using a rigid body.
 */
[RequireComponent(typeof(Rigidbody))]
public class LeftAndRight: MonoBehaviour {
    [Tooltip("The points between which the platform moves")]
    [SerializeField] Transform startPoint = null, endPoint = null;

    [SerializeField] float speed = 1f;

    private bool moveFromStartToEnd = true;

    private Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (moveFromStartToEnd) {
            rb.MovePosition(Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime));
        } else {  // move from end to start
            rb.MovePosition(Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime));
        }

        if (transform.position == startPoint.position) {
            moveFromStartToEnd = true;
        } else if (transform.position == endPoint.position) {
            moveFromStartToEnd = false;
        }
    }
}
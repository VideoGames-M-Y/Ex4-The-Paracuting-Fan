using UnityEngine;

/**
 * This component makes the fan blow wind, applying force to objects with a Rigidbody
 * within its trigger collider, but only when the mouse button is held down.
 */
public class WindBlower : MonoBehaviour
{
    [Header("Wind Settings")]
    [SerializeField] private float windForce = 10f;
    [SerializeField] private Vector3 windDirection = Vector3.forward;

    private bool isMouseDown = false;

    void Update()
    {
        // Check if the left mouse button is held down
        isMouseDown = Input.GetMouseButton(0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (isMouseDown)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Apply force in the fan's forward direction
                rb.AddForce(transform.TransformDirection(windDirection) * windForce, ForceMode.Force);
            }
        }
    }

    // Optional: Visualize the wind direction in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(windDirection) * 2f);
    }
}

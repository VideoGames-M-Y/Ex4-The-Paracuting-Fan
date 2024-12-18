using UnityEngine;

/**
 * This component moves its object in a fixed velocity.
 * NOTE: velocity is defined as speed+direction.
 *       speed is a number; velocity is a vector.
 */
public class Mover : MonoBehaviour
{
    [Tooltip("Movement vector in meters per second")]
    [SerializeField] private int speed = 1;

    void Update()
    {
        // Move the object in the forward direction
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}

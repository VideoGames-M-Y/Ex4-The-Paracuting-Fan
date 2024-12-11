using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 8f;

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }
}

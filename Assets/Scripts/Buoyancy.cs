using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]

public class Buoyancy : MonoBehaviour
{
    public float underwaterDrag = 3f;
    public float underwaterAngularDrag = 1f;
    public float airdrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;
    public float waterLevel = 0f;

    private Rigidbody rb;
    private bool isUnderwater;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float difference =transform.position.y - waterLevel;
        if (difference < 0){
            rb.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);
            if (!isUnderwater){
                isUnderwater = true;
                SwitchState(true);
            }
        }
        else if (isUnderwater){
            isUnderwater = false;
            SwitchState(false);
        }
    }

    void SwitchState(bool state)
    {
        if (state)
        {
            rb.linearDamping = underwaterDrag;
            rb.angularDamping = underwaterAngularDrag;
        }
        else
        {
            rb.linearDamping = airdrag;
            rb.angularDamping = airAngularDrag;
        }
    }

   
}

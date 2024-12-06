using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMotion : MonoBehaviour
{
    public float movementThreshold = 0.1f;
    private Rigidbody rb;
    private void Start(){
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        var joystickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (joystickInput.magnitude < movementThreshold)
        {
            // If joystick input is below the threshold, set motion to zero
            rb.velocity = Vector3.zero;
        }
    }
}
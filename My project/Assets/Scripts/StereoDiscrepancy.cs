using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StereoDiscrepancy : MonoBehaviour
{
    public float bounceHeight = 1f;
    public float bounceSpeed = 1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
        transform.Rotate(Vector3.up, 0.1f);
    }
}

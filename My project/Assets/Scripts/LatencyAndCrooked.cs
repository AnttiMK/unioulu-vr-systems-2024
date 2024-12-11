using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LatencyAndCrooked : MonoBehaviour
{
    private Vector3 delayedPosition;
    private Quaternion delayedRotation;

    private Vector3 currentPosition;
    private Quaternion currentRotation;

    public float latency = 0.2f;
    public float crookedAngle = 20f;
    private Queue<Vector3> positionQueue = new Queue<Vector3>();
    private Queue<Quaternion> rotationQueue = new Queue<Quaternion>();

    void Update()
    {
        InputDevice headset = InputDevices.GetDeviceAtXRNode(XRNode.Head);

        if (headset.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position))
        {
            currentPosition = position;
        }

        if (headset.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation))
        {
            currentRotation = rotation;
        }

        positionQueue.Enqueue(currentPosition);
        rotationQueue.Enqueue(currentRotation);

        while (positionQueue.Count > latency / Time.deltaTime)
        {
            delayedPosition = positionQueue.Dequeue();
        }

        while (rotationQueue.Count > latency / Time.deltaTime)
        {
            delayedRotation = rotationQueue.Dequeue();
        }

        transform.localPosition = delayedPosition;

        Quaternion crookedRotation = Quaternion.Euler(crookedAngle, 0, 0);
        transform.localRotation = delayedRotation * crookedRotation;
    }
}
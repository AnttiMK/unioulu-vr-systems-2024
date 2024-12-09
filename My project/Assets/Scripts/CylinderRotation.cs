using UnityEngine;
using UnityEngine.InputSystem;

public class CylinderRotation : MonoBehaviour
{
    public float rotationSpeed;
    public InputActionReference changeDirection = null;

    // Start is called before the first frame update
    void Start()
    {
        if (changeDirection != null)
        {
            changeDirection.action.Enable();
            changeDirection.action.performed += (ctx) =>
            {
                rotationSpeed *= -1;
            };
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, rotationSpeed/10, 0f);
    }
}

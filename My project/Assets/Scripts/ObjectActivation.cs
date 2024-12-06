using UnityEngine;

public class ObjectActivation : MonoBehaviour
{
    public Material activeMaterial;
    private Material defaultMaterial;
    private Renderer objectRenderer;
    private bool isActive = false;

    void Start()
    {
        // Get the renderer component of the object
        objectRenderer = GetComponent<Renderer>();

        // Store the default material
        defaultMaterial = objectRenderer.material;

        // Initially make the object clear
        SetObjectActive(false);
    }

    void Update()
    {
        // Check for input to toggle object activation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActive = !isActive;
            SetObjectActive(isActive);
        }
    }

    void SetObjectActive(bool active)
    {
        if (active)
        {
            // If active, apply the specified active material
            objectRenderer.material = activeMaterial;
        }
        else
        {
            // If not active, make the object clear
            objectRenderer.material = defaultMaterial;
            Color clearColor = objectRenderer.material.color;
            clearColor.a = 0f; // Set alpha to 0 to make the object clear
            objectRenderer.material.color = clearColor;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;

    private Material[] materials;

    public InputActionReference toggle;

    void Start()
    {
        materials = new Material[4];
        materials[0] = material1;
        materials[1] = material2;
        materials[2] = material3;
        materials[3] = material4;

        int i = 1;

        toggle.action.Enable();
        toggle.action.performed += (ctx) =>
        {
            gameObject.GetComponent<MeshRenderer>().material = materials[i%4];
            i++;
        };
    }
}

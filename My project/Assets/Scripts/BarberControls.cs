using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BarberControls : MonoBehaviour
{
    public InputActionReference teleport;
    public InputActionReference menu;
    public InputActionReference hideHoles;

    public GameObject holes;

    private XROrigin xrOrigin;

    // Start is called before the first frame update
    void Start()
    {
        xrOrigin = GetComponentInChildren<XROrigin>();

        Vector3 cylinder = new(-20, 0, 0);
        Vector3 defLocation = new(0, 0, 0);

        bool toggleState = false;
        bool hide = false;

        teleport.action.Enable();
        teleport.action.performed += (ctx) =>
        {
            if (toggleState)
            {
                xrOrigin.transform.position = defLocation;
                toggleState = !toggleState;
            } else
            {
                xrOrigin.transform.position = cylinder;
                toggleState = !toggleState;
            }
        };

        menu.action.Enable();
        menu.action.performed += (ctx) =>
        {
            SceneManager.LoadScene(0);
        };

        hideHoles.action.Enable();
        hideHoles.action.performed += (ctx) =>
        {
            holes.SetActive(hide);
            hide = !hide;
        };
    }
}

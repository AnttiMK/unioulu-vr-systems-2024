using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ReturnToMenu : MonoBehaviour
{
   
    public InputActionReference action;

    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
        SceneManager.LoadScene(0);
        };
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public event Action<Vector2> onMove;
    public event Action<Vector2> onLook;

    private Inputs inputs;
    private Vector2 moveInput;
    private Vector2 lookInput;

    private void OnEnable()
    {
        SetupInput();
        EnableInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }

    private void SetupInput()
    {
        inputs = new Inputs();

       
        inputs.PlayerMovement.Move.performed += OnMove;
        inputs.PlayerMovement.Look.performed += OnLook;
    }

    private void EnableInput()
    {
        inputs.PlayerMovement.Enable();
    }

    private void DisableInput()
    {
        inputs.PlayerMovement.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        onMove?.Invoke(moveInput);
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
        onLook?.Invoke(lookInput);
    }

    private void Update()
    {
        
        if (onMove != null)
        {
            onMove(moveInput);
        }

        if (onLook != null)
        {
            onLook(lookInput);
        }

    }

}

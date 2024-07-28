using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public event Action<Vector2> onMove;
    public event Action<Vector2> onLook;
    public event Action<Vector2> onZoom;
    public event Action<bool> onAttack;
    public event Action<bool> onOptionmenu;
    public event Action<bool> onUse;

    private Inputs inputs;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector2 zoomInput;

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
        inputs.PlayerMovement.Zoom.performed += OnZoom;

        inputs.PlayerInteract.Attack.performed += OnAttack;
        inputs.PlayerInteract.OptionMenu.performed += OnOptionmenu;
        inputs.PlayerInteract.Use.performed += OnUse;
        
    }

    private void EnableInput()
    {
        inputs.PlayerMovement.Enable();
        inputs.PlayerInteract.Enable();
    }

    private void DisableInput()
    {
        inputs.PlayerMovement.Disable();
        inputs.PlayerInteract.Disable();
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

    private void OnZoom(InputAction.CallbackContext context)
    {
        zoomInput = context.ReadValue<Vector2>();
        onZoom?.Invoke(zoomInput);
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        bool isAttacking = context.ReadValueAsButton();
        onAttack?.Invoke(isAttacking);
    }

    private void OnOptionmenu(InputAction.CallbackContext context)
    {
        bool isInteracting = context.ReadValueAsButton();
        onOptionmenu?.Invoke(isInteracting);
    }
    private void OnUse(InputAction.CallbackContext context)
    {
        bool isInteracting1 = context.ReadValueAsButton();
        onUse?.Invoke(isInteracting1);
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

        if (onZoom != null)
        {
            onZoom(zoomInput);
        }
    }

}

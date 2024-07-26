using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public event Action<Vector2> onMove;

    private Inputs inputs;
    private Vector2 moveInput;

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






    // playerInput.UseItem.RMB.performed += OnUseRMB;

    // playerInput.UseItem.LMB.performed += OnUseLMB;




    // playerInput.Enable();

    /*  private void OnUseRMB(InputAction.CallbackContext context)
      {

          float rightButtonValue = context.ReadValue<float>();
          if (rightButtonValue > 0.5f)
          {
              onUseRMB?.Invoke(true);
          }


      }
      private void OnUseLMB(InputAction.CallbackContext context)
      {
          float leftButtonValue = context.ReadValue<float>();
          if (leftButtonValue > 0.5f)
          {
              onUseLMB?.Invoke(true);
          }

      }*/

}

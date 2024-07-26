using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private Rigidbody playerRigidbody;

    [SerializeField] private float walkSpeed = 7f;

    private Vector3 _movementDirection;

    private void OnEnable()
    {
        inputManager.onMove += OnMove;
    }

    private void OnDisable()
    {
        inputManager.onMove -= OnMove;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void OnMove(Vector2 inputValue)
    {
        _movementDirection = new Vector3(inputValue.x, 0, inputValue.y);
        _movementDirection = Quaternion.Euler(0, playerTransform.eulerAngles.y, 0) * _movementDirection;
        _movementDirection = _movementDirection.normalized; // Normalize to ensure consistent speed
    }

    private void HandleMovement()
    {
        Vector3 velocity = _movementDirection * walkSpeed;
        playerRigidbody.velocity = new Vector3(velocity.x, playerRigidbody.velocity.y, velocity.z);
    }

}

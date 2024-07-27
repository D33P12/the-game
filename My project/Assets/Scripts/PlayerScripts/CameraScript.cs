using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10);
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private bool lookAtPlayer = true;
    [SerializeField] private Camera _camera;

    private void FixedUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (lookAtPlayer)
        {
            transform.LookAt(player);
        }

    }

    private void OnEnable()
    {
        inputManager.onZoom += OnZoom;
    }

    private void OnDisable()
    {
        inputManager.onZoom -= OnZoom;
    }

    private void OnZoom(Vector2 zoomValue)
    {
        if (_camera.orthographic)
        {
            float zoomChange = zoomValue.x;
            float newSize = Mathf.Clamp(_camera.orthographicSize - zoomChange, 6f, 11f);
            _camera.orthographicSize = newSize;
        }
    }
}
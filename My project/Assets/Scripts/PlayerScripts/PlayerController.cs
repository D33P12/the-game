using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float walkSpeed = 7f;

    [SerializeField] private float rotationSpeed = 10000f;
    [SerializeField] private float extraSpeed = 25f;
    [SerializeField] private float yRotation = 0f;

    public GameObject lightToggle;

    
    private bool isNearSwitch = false;

    private Vector3 _movementDirection;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
      
       lightToggle.SetActive(false);
        
        
    }
    private void OnEnable()
    {
        inputManager.onMove += OnMove;
        inputManager.onLook += OnLook;
        inputManager.onUse += OnUse;
    }

    private void OnDisable()
    {
        inputManager.onMove -= OnMove;
        inputManager.onLook -= OnLook;
        inputManager.onUse -= OnUse;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void Update()
    {
        HandleRotation();
    }
    private void OnMove(Vector2 inputValue)
    {

        _movementDirection = new Vector3(inputValue.x, 0, inputValue.y);

    }
    private void OnLook(Vector2 lookValue)
    {

        yRotation += lookValue.x * rotationSpeed * Time.deltaTime * extraSpeed;

    }
    private void OnUse(bool isIneracting1)
    {
       
        if(isIneracting1 && isNearSwitch)
        {
            lightToggle.SetActive(!lightToggle.activeSelf);
        }
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightSwitch"))
        {
            isNearSwitch = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LightSwitch"))
        {
            isNearSwitch = false;
            
        }
    }

    private void HandleMovement()
    {

        Vector3 velocity = _movementDirection * walkSpeed;
        playerRigidbody.velocity = new Vector3(velocity.x, playerRigidbody.velocity.y, velocity.z);

    }

    private void HandleRotation()
    {

        playerTransform.localRotation = Quaternion.Euler(0, yRotation, 0);

    }
    

}

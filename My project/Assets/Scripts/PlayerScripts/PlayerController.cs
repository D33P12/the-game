using UnityEngine;
using UnityEngine.Events;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float walkSpeed = 7f;

    [SerializeField] private float rotationSpeed = 10000f;
    [SerializeField] private float extraSpeed = 25f;
    [SerializeField] private float yRotation = 0f;

    public UnityEvent OnToggleLights;

    public GameObject lightToggle;

    private Animator animator;

    private bool isNearSwitch = false;

    private Vector3 _movementDirection;

    LightSwitch currentSwitch;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
      
       lightToggle.SetActive(false);
        animator = GetComponent<Animator>();

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
        UpdateAnimation();
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
            currentSwitch.SwitchLights();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightSwitch"))
        {
             currentSwitch =  other.GetComponent<LightSwitch>();

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
    private void UpdateAnimation()
    {

        Vector3 localVelocity = playerTransform.InverseTransformDirection(playerRigidbody.velocity);

        float forwardSpeed = localVelocity.x; 
        float sideSpeed = localVelocity.z; 

       
        sideSpeed = Mathf.Clamp(sideSpeed, -1f, 1f); 

       
        animator.SetFloat("forwardSpeed", forwardSpeed);
        animator.SetFloat("sideSpeed", sideSpeed);

    }

}

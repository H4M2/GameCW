using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float normalWalkSpeed = 0f;
    [SerializeField] bool lockCursor = true;
    [SerializeField] private Transform respawn;
    float bhop;
    private bool moveable = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    void Start()
    {
        normalWalkSpeed = walkSpeed;
        controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        if (moveable)
        {
            UpdateMouseLook();
            UpdateMovement();
        }
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded){ //check's if the player is on the ground

            velocityY = 0.0f;
            bhop -= Time.deltaTime;

            if (bhop <= 0)//resets the walk speed back to normal
            {
                walkSpeed = normalWalkSpeed;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded){//jumping code

            walkSpeed += 0.5f;
            bhop = 0.1f;
            velocityY += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            
        }
        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            this.moveable = false;
            FindObjectOfType<GameManager>().GameOver();
        }
        if (other.CompareTag("Finish"))
        {
            this.moveable = false;
            FindObjectOfType<GameManager>().GameWon();
        }
    }
}
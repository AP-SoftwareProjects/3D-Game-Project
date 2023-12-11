using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 80.0f;

    public GameObject playerBody;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;

    public GameObject head;
    private float playerRotationY = 0.0f; // Initialize player view rotation

    [HideInInspector] public bool canMove = true;
    float rotationX = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            moveDirection.y = jumpSpeed;
        else
            moveDirection.y = movementDirectionY;

        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove && playerBody)
        {
            // Mouse rotation
            playerRotationY += Input.GetAxis("Mouse X") * lookSpeed;
            rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

            transform.localRotation = Quaternion.Euler(0f, playerRotationY, 0f);
            head.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        }
    }
}

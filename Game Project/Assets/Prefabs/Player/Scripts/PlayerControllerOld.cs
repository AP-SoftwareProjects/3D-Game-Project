using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControllerOld : MonoBehaviour
{
    public float walkingSpeed = 5.25f;
    public float runningSpeed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public CinemachineVirtualCamera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    Animator animator;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!PlayerManager.Instance.IsPicking)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
                animator.SetTrigger("Jump");
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }
            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            characterController.Move(moveDirection * Time.deltaTime);

            bool isStandingStill = moveDirection.x == 0 && moveDirection.z == 0;

            if (!isStandingStill)
            {
                if (isRunning)
                {
                    animator.SetBool("Sprinting", true);
                    animator.SetBool("Walking", false);
                }
                else
                {
                    animator.SetBool("Sprinting", false);
                    animator.SetBool("Walking", true);
                }
            }
            else
            {
                animator.SetBool("Walking", false);
                animator.SetBool("Sprinting", false);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerWalkSpeed = 3.0f;
    [SerializeField] private float playerSprintSpeed = 4.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private GameObject playerbody;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Transform cameraTransform;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        bool isSprinting = inputManager.PlayerSprinting();
        Vector3 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;

        // Set player rotation to match the camera rotation
        playerbody.transform.rotation = Quaternion.Euler(0, cameraTransform.rotation.eulerAngles.y, 0);

        controller.Move(move * Time.deltaTime * (isSprinting ? playerSprintSpeed : playerWalkSpeed));

        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        bool isStandingStill = move.x == 0 && move.z == 0;
        if (!isStandingStill)
        {
            if (isSprinting)
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

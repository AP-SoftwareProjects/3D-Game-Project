using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] public float playerWalkSpeed = 3.0f;
    [SerializeField] public float playerSprintSpeed = 4.0f;
    [SerializeField] public float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private GameObject playerbody;
    [SerializeField] private GameObject direction;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Transform cameraTransform;
    private Animator animator;
    private PlayerManager playerManager;

    //AUDIO
    public AudioClip runningSound;
    public AudioClip backgroundSound;

    private AudioSource walkAudioSource;
    private AudioSource runAudioSource;
    private AudioSource backgroundAudioSource;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        animator = GetComponent<Animator>();
        playerManager = PlayerManager.Instance;

        walkAudioSource = gameObject.AddComponent<AudioSource>();
        runAudioSource = gameObject.AddComponent<AudioSource>();

        backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundAudioSource.clip = backgroundSound;
        backgroundAudioSource.loop = true;
        backgroundAudioSource.volume = 0.04f;
        backgroundAudioSource.Play();
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
        move = direction.transform.forward * move.z + direction.transform.right * move.x;
        move.y = 0f;

        // Set player rotation to match the camera rotation
        if (playerManager.IsPicking)
            move = Vector3.zero;
        else
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

                if (!runAudioSource.isPlaying)
                {
                    walkAudioSource.Stop();
                    runAudioSource.clip = runningSound;
                    runAudioSource.loop = true;
                    runAudioSource.pitch = 1.6f;
                    runAudioSource.volume = 0.05f;
                    runAudioSource.Play();
                }
            }
            else
            {
                animator.SetBool("Sprinting", false);
                animator.SetBool("Walking", true);

                if (!walkAudioSource.isPlaying)
                {
                    runAudioSource.Stop();
                    walkAudioSource.clip = runningSound;
                    walkAudioSource.loop = true;
                    walkAudioSource.pitch = 1.3f;
                    walkAudioSource.volume = 0.05f;
                    walkAudioSource.Play();
                }
            }
        }
        else
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Sprinting", false);
            walkAudioSource.Stop();
            runAudioSource.Stop();
        }
    }
}

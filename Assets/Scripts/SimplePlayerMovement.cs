using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimplePlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float runSpeed = 5.0f;
    public Animation animationComponent;
    public CharacterController controller;
    public Transform cameraTransform;

    [HideInInspector] public bool hasSpeedBoost = false;

    private float _turnSmoothVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animationComponent = GetComponent<Animation>();
    }

    void Update()
    {
        if (PauseMenu.isPaused) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            // Smooth rotation toward camera-relative movement direction
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, 0.45f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            float speed = isRunning ? runSpeed : walkSpeed;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            // Animation
            if (isRunning)
                animationComponent.CrossFade("run");   // Running animation
            else
                animationComponent.CrossFade("walk");  // Walking animation
        }
        else
        {
            animationComponent.CrossFade("idle");      // Idle animation
        }
    }
}
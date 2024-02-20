using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Floats")]
    private float moveSpeed;
    public float walkSpeed;
    public float SprintSpeed;

    float horizontalInput;
    float verticalInput;

    [Header("Ground Check")]
    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool isGrounded;

    [Header("Jump Variables")]
    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Movement Transforms")]
    public Transform orientation;

    [Header("Movement Vectors")]
    Vector3 moveDirection;

    [Header("Movement Refrences")]
    Rigidbody playerRB;

    [Header("Slope Handling")]
    public float maxSlopAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    [Header("Keys")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    public MovementState state;

    public bool isWalking;

    public enum MovementState
    {
        walking,
        sprinting,
        air
    }

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.freezeRotation = true;

        readyToJump = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        LimitSpeed();
        StateHandler();

        if (isGrounded)
            playerRB.drag = groundDrag;
        else
            playerRB.drag = 2;

        if(verticalInput !=0 || horizontalInput !=0)
            isWalking = true;
        else 
            isWalking = false;
    }
    
    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && isGrounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCoolDown);
        }
    }

    void StateHandler()
    {
        if(isGrounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = SprintSpeed;
        }

        else if(isGrounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        else
        {
            state = MovementState.air;
        }
    }

    void MovePlayer()
    {
        moveDirection = (orientation.forward * verticalInput + orientation.right * horizontalInput).normalized;

        if (OnSlope() && !exitingSlope)
        {
            playerRB.AddForce(GetSlopeDirection() * moveSpeed * 20f, ForceMode.Force);

            if (playerRB.velocity.y > 0)
                playerRB.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        else if (isGrounded)
            playerRB.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!isGrounded)
            playerRB.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        playerRB.useGravity = !OnSlope();
    }

    void LimitSpeed()
    {
        if (OnSlope() && !exitingSlope)
        {
            if (playerRB.velocity.magnitude > moveSpeed)
                playerRB.velocity = playerRB.velocity.normalized * moveSpeed;
        }
        else
        {
            Vector3 flatVelocity = new Vector3(playerRB.velocity.x, 0f, playerRB.velocity.z);

            if (flatVelocity.magnitude > moveSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
                playerRB.velocity = new Vector3(limitedVelocity.x, playerRB.velocity.y, limitedVelocity.z);
            }
        }
    }

    void Jump()
    {
        exitingSlope = true;

        playerRB.velocity = new Vector3(playerRB.velocity.x, 0f, playerRB.velocity.z);

        playerRB.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    }
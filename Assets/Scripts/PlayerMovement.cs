using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //control player movement speed
    public float moveSpeed = 5f;
    //force applied when jumping
    public float jumpForce = 10f;
    //force applied for wall jumps
    public float wallJumpForce = 7f;
    //transform position to check if the player is grounded
    public Transform groundCheck;
    //LayerMask for defining what is considered ground
    public LayerMask groundLayer;
    //radius for ground check circle
    public float groundCheckRadius = 0.2f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool facingRight = true;
    private bool isTouchingWall;
    private bool canWallJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //checks if the player is grounded using Physics.CheckSphere
    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }

    //handles player movement using Input.GetAxis("Horizontal") and applies velocity to the Rigidbody
    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Flip(moveInput);

        //player movement
        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0);

        //jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        }

        //wall jump
        isTouchingWall = Physics.Raycast(transform.position, transform.right * transform.localScale.x, 0.1f, groundLayer);
        canWallJump = isTouchingWall && !isGrounded;

        if (canWallJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(-transform.localScale.x * wallJumpForce, jumpForce, 0);
        }
    }

    //method flips the player sprite horizontally based on movement direction (moveInput)
    private void Flip(float moveInput)
    {
        if (moveInput > 0 && !facingRight || moveInput < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
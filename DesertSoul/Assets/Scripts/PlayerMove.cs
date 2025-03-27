using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    private Vector2 horizontal;
    private float vertical;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpPower = 16f;
    [SerializeField] private float launchPower = 10f;
    private bool isFacingRight = true;
    [SerializeField] private float baseGravity = 2f;
    [SerializeField] private float gravLimit = 10f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private PlayerInputActions playerControls;
    [SerializeField] private InputAction move;
    [SerializeField] private InputAction look;


    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        horizontal = move.ReadValue<Vector2>();
        vertical = look.ReadValue<float>();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
        look.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(horizontal.x * speed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        //Gets player input and jumps if grounded
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new(rb.linearVelocity.x, jumpPower);
        }

        if(Input.GetButtonDown("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        //makes player decend faster the longer they are falling
        if(rb.linearVelocity.y < 0 && rb.gravityScale < gravLimit)
        {
            rb.gravityScale = rb.gravityScale + 0.005f;
        }

        //sets player gravity back to normal after being grounded
        if(IsGrounded())
        {
            rb.gravityScale = baseGravity;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}

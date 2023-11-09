using UnityEngine;

public class PlayerControllerComponent : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode runKey = KeyCode.LeftShift;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;
    public GameObject camObj;
    public Transform orientationBODYPLAYER;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;


    [SerializeField] Animator animator; 

    private void Start()
    {
        orientationBODYPLAYER = GameObject.Find("PLAYER").GetComponent<Transform>();
        rb = orientationBODYPLAYER.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private float xRotation;
    private float yRotation;
    private void cameraDo()
    {
        int sensX = 100;
        int sensY = 80;
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        camObj.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientationBODYPLAYER.rotation = Quaternion.Euler(0, yRotation, 0);   
    }
    bool lastGroundedStatus = true;
    private void Update()
    {
        cameraDo();

        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        Debug.DrawRay(transform.position, Vector3.down, Color.red, playerHeight * 0.5f + 0.3f);
        
        
        MyInput();
        SpeedControl();
        if (grounded && lastGroundedStatus == false)
            animator.SetBool("LAND", true);
        lastGroundedStatus = grounded;
        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if(animator.GetBool("WALK"))
        {
            //Walk();
        }

        if (animator.GetBool("RUN"))
        {
            //Run();
        }


        if (animator.GetBool("JUMP"))
        {
            Jump();
        }


        if (animator.GetBool("IDLE"))
        {
            //Stop();
        }


    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            animator.SetBool("JUMP", true);
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        else if(Input.GetKey(forwardKey) && Input.GetKey(runKey))
        {
            animator.SetBool("RUN", true);
        }
        else if(Input.GetKey(forwardKey))
            animator.SetBool("WALK", true);
        else 
            animator.SetBool("IDLE", true);
        
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
        animator.SetBool("JUMP", false);
    }
}

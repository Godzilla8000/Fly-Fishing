using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    [Header("FineTTunes Movement and Jumping")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float dashForce;
    [SerializeField] private float cooldownLength;

    [Header("Handles Gravity")]
    public float fallMultiplier;

    [SerializeField] private float rayLength;
    
    private float trueSpeed;
    public GameObject Camera;

    private Vector3 linVel;
    private Vector3 verVel;
    private Vector3 dashVel;

    private Vector3 trueVel;

    private Quaternion camRot;
    private Quaternion adCamRot;

    [SerializeField] private float cooldown;

    private Vector2 moveDirection;
    private float isSprinting;
    private float isJumping;
    private float isDashing;

    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference sprint;
    public InputActionReference dash;



    // Update is called once per frame

    private void Start()
    {
        verVel = transform.up * jumpForce;
    }
    void Update()
    {
        cooldown -= Time.deltaTime;

        moveDirection = move.action.ReadValue<Vector2>();
        //isSprinting = sprint.action.ReadValue<float>();
        isJumping = jump.action.ReadValue<float>();
        isDashing = dash.action.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (isSprinting == 0)
        {
            trueSpeed = moveSpeed;
        }
        if (isSprinting == 1)
        {
            trueSpeed = sprintSpeed;
        }

        
        if (isJumping != 0 && getIsGrounded())
        {
            rb.AddForce(verVel, ForceMode.Force);
        }

        dashVel = adCamRot * transform.forward * dashForce;
        if (isDashing != 0 && cooldown < 0)
        {
            rb.AddForce(dashVel, ForceMode.Force);
            cooldown = cooldownLength;
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);

        linVel = new Vector3(moveDirection.x * trueSpeed, 0, moveDirection.y * trueSpeed);
        camRot = Camera.transform.rotation;

        adCamRot = new Quaternion(0, camRot.y, camRot.z, camRot.w);
        //camRot.x

        rb.linearVelocity += adCamRot * linVel * Time.deltaTime;

       // rb.AddForce(linVel, ForceMode.Force);

        if (getIsGrounded() == false)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1f) * Time.deltaTime;
        }

        Debug.Log(trueSpeed);

        Debug.DrawRay(transform.position, Camera.transform.forward * rayLength, Color.green);
        Debug.DrawRay(transform.position, transform.up * -rayLength, Color.green);
    }

    private bool getIsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, LayerMask.GetMask("Floor"));
        
    }
}

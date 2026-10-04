using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject camera;

    public float sensitivityX;
    public float sensitivityY;

    private float xRot;
    private float yRot;

    private Vector2 lookDirection;

    public InputAction look;
    // Update is called once per frame
    private void Start()
    {
        look.Enable();
    }
    void Update()
    {
        lookDirection = look.ReadValue<Vector2>();
    }


    private void FixedUpdate()
    {

        Mathf.Clamp(lookDirection.y, -90f, 90f);

        xRot += lookDirection.x * sensitivityX;
        yRot -= lookDirection.y * sensitivityY;

        rb.transform.localRotation = Quaternion.Euler(yRot, xRot, 0f);

        Debug.Log(xRot);
    }
}

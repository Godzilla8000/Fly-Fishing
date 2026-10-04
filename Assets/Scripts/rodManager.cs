using UnityEngine;
using UnityEngine.InputSystem;

public class rodManager : MonoBehaviour
{
    public Animator rodAnim;

    private float rodAnimNum;
    public float animLength;

    private float isSwinging;

    public InputActionReference swing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rodAnimNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rodAnim.SetFloat("IsSwing",rodAnimNum);

        rodAnimNum = swing.action.ReadValue<float>();
    }
}

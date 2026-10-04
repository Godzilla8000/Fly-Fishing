using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;

    [SerializeField] private float dashTime = 2;
    [SerializeField] private float dashForce;

    private float dash;

    Vector3 playerpos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dash = dashTime;
    }

    // Update is called once per frame
    void Update()
    {
        dash -= Time.deltaTime;
        if (0 > dash)
        {
            playerpos = (player.transform.position - transform.position) * dashForce;
            rb.AddForce(playerpos, ForceMode.Force);
            dash = dashTime;
        }
    }
}

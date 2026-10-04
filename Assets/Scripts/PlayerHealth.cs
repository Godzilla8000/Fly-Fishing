using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    [SerializeField] private float maxHealth = 10;
    private float iFrames;
    [SerializeField] private float maxiFrames = 2;
    [SerializeField] private float enemy1DMG = 3;

    public Slider healthBar;

   void Start()
    {
        health = maxHealth;
        iFrames = maxiFrames;
    }

    // Update is called once per frame
    void Update()
    {
        iFrames -= Time.deltaTime;
        healthBar.value = health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && iFrames < 0)
        {
            health -= enemy1DMG;
            iFrames = maxiFrames;
            Debug.Log(health);
        }
    }
}

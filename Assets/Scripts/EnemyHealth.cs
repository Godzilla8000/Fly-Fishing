using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10;
    private float health;
    [SerializeField] private float maxiFrames = 0.5f;
    private float iFrames;
    [SerializeField] private float weaponDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        iFrames -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon") && iFrames < 0)
        {
            health -= weaponDamage;
            iFrames = maxiFrames;
            Debug.Log(health);

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

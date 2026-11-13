using UnityEditor.Toolbars;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public Material baseMaterial;
    public Material attackMaterial;
    public GameObject Enemy;
    public GameObject Hitbox;

    [SerializeField] private float attackInterval = 2.5f;
    [SerializeField] private float attackDuaration = 1;
    private float attack;
    private bool isAttacking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy.GetComponent<Renderer>().material = baseMaterial;
        attack = attackInterval;
        isAttacking = true;
    }

    // Update is called once per frame
    void Update()
    {
        attack -= Time.deltaTime;
        if (attack < 0)
        {
            Debug.Log(isAttacking);
            if (isAttacking == false)
            {
                attack = attackDuaration;
                Enemy.GetComponent<Renderer>().material = attackMaterial;
                Hitbox.SetActive(true);
                isAttacking = true;
            }
            if (isAttacking == true)
            {
                attack = attackInterval;
                Enemy.GetComponent<Renderer>().material = baseMaterial;
                Hitbox.SetActive(false);               
                isAttacking = false;
            }
            
        }
      
    }
}

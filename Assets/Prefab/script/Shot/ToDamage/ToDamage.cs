using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDamage : MonoBehaviour
{
    public Enemy enemy1;
    public Enemy enemy2;
    private float Damage;
    Basic_Auto_Shot Basic_Auto_Shot;
    // Start is called before the first frame update
    
    private void Start()
    {
        Basic_Auto_Shot = GameObject.Find("BasicAttack").GetComponent<Basic_Auto_Shot>();
    }
    
    private void Awake()
    {
        Damage = Basic_Auto_Shot.SpellDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            enemy1.TakeDamage(Damage);
            enemy2.TakeDamage(Damage);
        }
        


    }
}

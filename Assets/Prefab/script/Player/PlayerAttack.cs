using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Mage Mage;
    
    //hit
    public GameObject hitBoxCollider;
    public float hitRecovery = 1f;
    public SpriteRenderer[] sprites;
    bool invincible;
    // Start is called before the first frame update
    /*
    [SerializeField] GameObject SpellPrefab;

    [SerializeField] SpriteRenderer SpellGFX;

    [SerializeField] Slider SpellPowerSlider;

    [SerializeField] Transform Spell;

    [Range(0, 10)]

    [SerializeField] float SpellPower;
    */

    //bool CanFire = true;
    private void Awake()
    {
        StartCoroutine(ResetCollider());
    }
    private void Start()
    {
        //SpellPowerSlider.value = 0f;
        //SpellPowerSlider.maxValue = 50f;
        
     
    }


    // Update is called once per frame
    private void Update()
    {
        //if (CanFire)
        //{
        //    FireSpell();
        //}
        

    }
    /*
    void FireSpell()
    {
        
    }
    
    private IEnumerable SearchTarget()
    {
        while (true)
        {
            float closestDistSqr = Mathf.Infinity;
            
            for(int i = 0; i < EnemySpawn.E; ++i)
            {

            }
        }
    }
    */
    IEnumerator ResetCollider()
    {
        while (true)
        {
            yield return null;
            if (!hitBoxCollider.activeInHierarchy)
            {
                yield return new WaitForSeconds(hitRecovery);
                hitBoxCollider.SetActive(true);
            }
        }
    }

    IEnumerator InvincibleEffect()
    {
        invincible = true; //무적
        yield return new WaitForSeconds(0.5f);

        invincible = false; //무적해제
    }
    private void OnTriggerEnter2D(Collider2D collision) // hitted
    {
        if (collision.transform.CompareTag("Enemy")||collision.transform.CompareTag("MonsterHitBox"))
        {
            if (!invincible)
            {
                StartCoroutine(InvincibleEffect());
                PlayerHealth.health -= Enemy.attackDamage;
                Debug.Log("HP--");
            }
            if (PlayerHealth.health > 0f)
            {
                
                //Mage.m_body2d.velocity = Vector2.zero;
                Mage.isHit = true;
                Invoke("isHitReset", 0.5f);
                hitBoxCollider.SetActive(false);

                Mage.MyAnimSetTrigger("hurt");
            }
            else if (PlayerHealth.health == 0f)
            {
                PlayerDie();
            }
        }
    }


    void PlayerDie()
    {
        Mage.MyAnimSetTrigger("Die");
        invincible = true;
        Mage.m_body2d.velocity = Vector2.zero;
        Mage.isDie = true;
        hitBoxCollider.SetActive(false);
        Debug.Log("Player Die");
    }
    void isHitReset()
    {
        Mage.isHit = false;
    }
}

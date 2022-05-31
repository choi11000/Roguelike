using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    public Image healthBar;
    public static event Action OnPlayerDeath;
    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
        healthBar = GetComponent<Image>();
    }
    
    // Update is called once per frame
    /*
    public void UpdateHealth(float dmg)
    {
        health -= dmg;

        if(health > maxHealth)
        {
            health = maxHealth;
        }else if (health <= 0f)
        {
            health = 0f;
            Debug.Log("Player Die");
        }
    }
    */
    private void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if (health == 0)
        {
            OnPlayerDeath?.Invoke();
            
        }
    }
}

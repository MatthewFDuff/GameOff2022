using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{

    public int PlayerMaxHealth = 100;
    public int PlayerCurrentHealth;

    public PlayerHealthBar healthBar;
   

    public void Start()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        healthBar.SetMaxHealth(PlayerMaxHealth);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void SetMaxHealth(int health)
    {
        //slider.maxValue = health;
       // slider.value = health;
    }

    

    void TakeDamage(int damage)
    {
        PlayerCurrentHealth -= damage;

        healthBar.SetHealth(PlayerCurrentHealth);
    }
}

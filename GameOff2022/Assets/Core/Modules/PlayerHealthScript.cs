using Core.Scripts;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour, IDamageable
{

    public int PlayerMaxHealth = 100;
    public int PlayerCurrentHealth;

    public PlayerHealthBar healthBar;
    
    public void Start()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        healthBar.SetMaxHealth(PlayerMaxHealth);
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

    public void Damage(int amount)
    {
        TakeDamage(amount);
    }
}

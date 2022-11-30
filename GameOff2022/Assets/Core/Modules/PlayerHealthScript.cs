using Core.Scripts;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthScript : MonoBehaviour, IDamageable
{

    public int PlayerMaxHealth = 100;
    public int PlayerCurrentHealth;

    public PlayerHealthBar healthBar;

    public UnityEvent death;
    
    public void Start()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        healthBar.SetMaxHealth(PlayerMaxHealth);
    }

    void TakeDamage(int damage)
    {
        PlayerCurrentHealth -= damage;

        healthBar.SetHealth(PlayerCurrentHealth);
        if(PlayerCurrentHealth >= 0) death?.Invoke();
    }

    public void Damage(int amount)
    {
        TakeDamage(amount);
    }
}

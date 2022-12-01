using Core.Scripts;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthScript : MonoBehaviour, IDamageable
{

    public int PlayerMaxHealth = 100;
    public int PlayerCurrentHealth;

    [SerializeField] private Animator _animator;
    
    public PlayerHealthBar healthBar;

    public UnityEvent death;
    private static readonly int IsHurt = Animator.StringToHash("IsHurt");

    public void Start()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        healthBar.SetMaxHealth(PlayerMaxHealth);
    }

    void TakeDamage(int damage)
    {
        Debug.Log("Player taking damage");
        _animator.SetBool(IsHurt, true);
        PlayerCurrentHealth -= damage;
        

        healthBar.SetHealth(PlayerCurrentHealth);
        if(PlayerCurrentHealth <= 0) death?.Invoke();
        
        _animator.SetBool(IsHurt, false);
    }

    public void Damage(int amount)
    {
        TakeDamage(amount);
    }
}

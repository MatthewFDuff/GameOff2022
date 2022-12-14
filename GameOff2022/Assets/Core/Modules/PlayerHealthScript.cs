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
        _animator.SetBool(IsHurt, true);
        
        GetComponent<AudioSource>().Play();
        
        PlayerCurrentHealth -= damage;
        

        healthBar.SetHealth(PlayerCurrentHealth);
        if(PlayerCurrentHealth <= 0) death?.Invoke();
        
        Invoke(nameof(StopHurting), 0.5f);
    }

    void StopHurting()
    {
        _animator.SetBool(IsHurt, false);
    }

    public void Damage(int amount)
    {
        TakeDamage(amount);
    }
}

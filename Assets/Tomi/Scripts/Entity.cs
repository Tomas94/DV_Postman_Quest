using UnityEngine;
using UnityEngine.SceneManagement;

public class Entity : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [SerializeField] protected int _maxHP;
    [SerializeField] protected int _currentHP;
    [SerializeField] protected float _speed;

    [Header("Attack Stats")]
    [SerializeField] protected int _damagePower;
    [SerializeField] protected float _atkCooldown;
    [SerializeField] protected float _atkDuration;

    public int CurrentHP { get { return _currentHP; } }

    virtual public void Awake()
    {
        _currentHP = _maxHP;
    }
    
    virtual public void TakeDamage(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0) Die();
    }

    virtual public void Die()
    {
        _currentHP = _maxHP;
    }
}

using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    
    public event Action HealthChanged;
    
    public float Health => _health;
    public float MaxHealth { get; private set; }
    
    private void Start()
    {
        MaxHealth = _health;
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke();

        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int Attack()
    {
        return _damage;
    }
}
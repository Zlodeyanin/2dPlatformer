using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        
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
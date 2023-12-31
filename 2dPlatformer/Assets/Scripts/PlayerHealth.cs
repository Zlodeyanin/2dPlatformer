using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    private Vector2 _startPosition;
    private int _startHealth;

    private void Start()
    {
        _startPosition = transform.position;
        _startHealth = _health;
    }

    public void Heal(int heal)
    {
        if(_health <= _startHealth - heal)
            _health += heal;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        
        if (_health <= 0)
        {
            transform.position = _startPosition;
            _health = 100;
        }
    }
}
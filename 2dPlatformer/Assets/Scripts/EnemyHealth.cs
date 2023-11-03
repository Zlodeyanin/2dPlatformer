using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private void Update()
    {
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
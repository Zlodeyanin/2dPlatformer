using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
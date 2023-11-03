using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage;

    public int Attack()
    {
        return _damage;
    }
}
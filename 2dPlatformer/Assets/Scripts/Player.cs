using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyMovement enemy))
        {
            transform.position = _startPosition;
        }
    }
}
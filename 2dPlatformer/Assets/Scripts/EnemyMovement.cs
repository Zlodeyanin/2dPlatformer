using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _flip;
    private float _direction = -1;
    private float _zeroMove = 0;

    private void Update()
    {
        bool isFlip = true && _direction > 0;
        _flip.flipX = isFlip;
        transform.Translate(_speed * _direction * Time.deltaTime, _zeroMove, _zeroMove);
    }

    private void Start()
    {
        _flip = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Obctacle obctacle))
        {
            ChangeDirection();
        }
    }

    private float ChangeDirection()
    {
        if (_direction == 1)
        {
            _direction = -1;
        }
        else
        {
            _direction = 1;
        }
        
        return _direction;
    }
}
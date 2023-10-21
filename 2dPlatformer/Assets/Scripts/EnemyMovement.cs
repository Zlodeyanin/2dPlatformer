using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;

    private SpriteRenderer _flip;
    private float _seeDistance = 3f;
    private float _direction = -1;
    private float _zeroMove = 0;

    private void Start()
    {
        _flip = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        bool isFlip = true && _direction > 0;
        _flip.flipX = isFlip;
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Obctacle obctacle))
        {
            ChangeDirection();
        }
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < _seeDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(_speed * _direction * Time.deltaTime, _zeroMove, _zeroMove);
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
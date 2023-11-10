using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public readonly int Speed = Animator.StringToHash(nameof(Speed));

    [SerializeField] private float _playerSpeed;

    private Animator _animator;
    private float _zeroMove = 0;
    private float _playerGo = 1f;
    private SpriteRenderer _flip;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _flip= GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MovePlayer();

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(_zeroMove, _playerSpeed * Time.deltaTime * 3, _zeroMove);
        }

    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _flip.flipX = true;
            transform.Translate(_playerSpeed * Time.deltaTime * -1, _zeroMove, _zeroMove);
            _animator.SetFloat(Speed, _playerGo);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _flip.flipX = false;
            transform.Translate(_playerSpeed * Time.deltaTime, _zeroMove, _zeroMove);
            _animator.SetFloat(Speed, _playerGo);
        }
        else
        {
            _animator.SetFloat(Speed, _zeroMove);
        }
    }
}
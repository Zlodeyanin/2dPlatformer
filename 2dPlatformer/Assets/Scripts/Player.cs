using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public readonly int Attack = Animator.StringToHash(nameof(Attack));

    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private Vector2 _startPosition;
    private Enemy _enemy;
    private Animator _animator;
    private Coroutine _battle;
    private bool _isBattle;
    private int _startHealth;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _startPosition = transform.position;
        _startHealth = _health;
    }

    private void Update()
    {
        _animator.SetBool(Attack, _isBattle);

        if (_health <= 0)
        {
            transform.position = _startPosition;
            _health = 100;
            Debug.Log("You Lose!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            _enemy = enemy;
            _isBattle = true;
            _battle = StartCoroutine(Battle());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            _isBattle = false;
            StopCoroutine(_battle);
        }
    }

    public void Heal(int heal)
    {
        if(_health <= _startHealth - heal)
        _health += heal;
    }

    private IEnumerator Battle()
    {
        WaitForSeconds rechargeAttack = new WaitForSeconds(1f);

        while (_isBattle)
        {
            _enemy.TakeDamage(_damage);
            _health -= _enemy.Attack();
            yield return rechargeAttack;
        }
    }
}
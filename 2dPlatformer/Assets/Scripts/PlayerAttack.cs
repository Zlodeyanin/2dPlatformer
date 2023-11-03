using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerAttack : MonoBehaviour
{
    public readonly int Attack = Animator.StringToHash(nameof(Attack));

    [SerializeField] private int _damage;

    private PlayerHealth _player;
    private EnemyHealth _enemy;
    private Animator _animator;
    private Coroutine _battle;
    private bool _isBattle;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player= GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        _animator.SetBool(Attack, _isBattle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyHealth enemy))
        {
            _enemy = enemy;
            _isBattle = true;
            _battle = StartCoroutine(Battle());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyHealth enemy))
        {
            _isBattle = false;
            StopCoroutine(_battle);
        }
    }

    private IEnumerator Battle()
    {
        WaitForSeconds rechargeAttack = new WaitForSeconds(1f);

        while (_isBattle)
        {
            _enemy.TakeDamage(_damage);
            _enemy.TryGetComponent(out EnemyAttack enemyAttack);
            _player.TakeDamage(enemyAttack.Attack());
            yield return rechargeAttack;
        }
    }
}

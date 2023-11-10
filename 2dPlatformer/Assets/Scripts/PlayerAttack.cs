using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerAttack : MonoBehaviour
{
    public readonly int Attack = Animator.StringToHash(nameof(Attack));

    [SerializeField] private int _damage;

    private PlayerHealth _player;
    private Enemy _enemy;
    private Animator _animator;
    private Coroutine _battle;
    private bool _isBattle;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player= GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            _enemy = enemy;
            _isBattle = true;
            _battle = StartCoroutine(Battle());
            _animator.SetBool(Attack, _isBattle);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            _isBattle = false;
            StopCoroutine(_battle);
            _animator.SetBool(Attack, _isBattle);
        }
    }

    private IEnumerator Battle()
    {
        WaitForSeconds rechargeAttack = new WaitForSeconds(1f);

        while (_isBattle)
        {
            _enemy.TakeDamage(_damage);
            _enemy.TryGetComponent(out Enemy enemyAttack);
            _player.TakeDamage(enemyAttack.Attack());
            yield return rechargeAttack;
        }
    }
}

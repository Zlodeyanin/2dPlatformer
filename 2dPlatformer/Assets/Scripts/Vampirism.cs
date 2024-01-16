using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private float _vampirismSpeed;
    [SerializeField] private int _vampirismStrenght;

    private Enemy _currentEnemy;
    private Coroutine _vampirism;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            _currentEnemy = enemy;
            _vampirism = StartCoroutine(RunVampirism());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(_vampirism != null)
            StopCoroutine(_vampirism);
        
        _currentEnemy = null;
    }

    private IEnumerator RunVampirism()
    {
        WaitForSeconds vampirismSpeed = new WaitForSeconds(_vampirismSpeed);
        
        while (_currentEnemy != null)
        {
            if (_player.Health != _player.MaxHealth)
            {
                _player.Heal(_vampirismStrenght);
                _currentEnemy.TakeDamage(_vampirismStrenght);
            }
            yield return vampirismSpeed;
        }
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _speed;
    
    private Slider _healthBar;
    private Coroutine _changeHealth;
    private float _currentHealth;
    
    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _currentHealth = _enemy.Health / _enemy.MaxHealth;
        _healthBar.value = _currentHealth;
    }

    private void OnEnable()
    {
        _enemy.HealthChanged += ChangeBarValue;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= ChangeBarValue;
    }

    private void ChangeBarValue()
    {
        if (_changeHealth == null)
        {
            _changeHealth = StartCoroutine(SmoothChangeValue());
        }

        if (_enemy == null)
        {
            StopCoroutine(_changeHealth);
        }
    }

    private IEnumerator SmoothChangeValue()
    {
        while (true)
        {
            _currentHealth = _enemy.Health / _enemy.MaxHealth;
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _currentHealth,_speed * Time.deltaTime);
            yield return null;
        } 
    }
}

using System.Collections;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private Money _money;
    [SerializeField] private Transform _moneySpawnPositions;
    [SerializeField] private float _moneyRespawnTime;

    private Transform[] _spawnPoints;
    private Coroutine _spawner;
    private bool _isSpawning;

    private void Start()
    {
        _spawnPoints = new Transform[_moneySpawnPositions.childCount];

        for (int i = 0; i < _moneySpawnPositions.childCount; i++)
        {
            _spawnPoints[i] = _moneySpawnPositions.GetChild(i);
        }

        StartSpawnEnemies();
    }

    private void StartSpawnEnemies()
    {
        if (_spawnPoints.Length > 0)
        {
            _spawner = StartCoroutine(SpawnMoneys());
        }
        else
        {
            _isSpawning = false;
            StopCoroutine(_spawner);
        }
    }

    private IEnumerator SpawnMoneys()
    {
        WaitForSeconds respawnTime = new WaitForSeconds(_moneyRespawnTime);
        int spawnPointsMaxIndex = _spawnPoints.Length;
        int spawmPointsMinIndex = 0;
        _isSpawning = true;

        while (_isSpawning)
        {
            int index = Random.Range(spawmPointsMinIndex, spawnPointsMaxIndex);
            Instantiate(_money.gameObject, _spawnPoints[index].transform);
            yield return respawnTime;
        }
    }
}
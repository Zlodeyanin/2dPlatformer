using System.Collections;
using UnityEngine;

public class MedecineSpawner : MonoBehaviour
{
    [SerializeField] private Medecine _medecine;
    [SerializeField] private Transform _medecineSpawnPositions;
    [SerializeField] private float _medecineRespawnTime;

    private Transform[] _spawnPoints;
    private Coroutine _spawner;
    private bool _isSpawning;

    private void Start()
    {
        _spawnPoints = new Transform[_medecineSpawnPositions.childCount];

        for (int i = 0; i < _medecineSpawnPositions.childCount; i++)
        {
            _spawnPoints[i] = _medecineSpawnPositions.GetChild(i);
        }

        StartSpawnEnemies();
    }

    private void StartSpawnEnemies()
    {
        if (_spawnPoints.Length > 0)
        {
            _spawner = StartCoroutine(SpawnFirtsAidBox());
        }
        else
        {
            _isSpawning = false;
            StopCoroutine(_spawner);
        }
    }

    private IEnumerator SpawnFirtsAidBox()
    {
        WaitForSeconds respawnTime = new WaitForSeconds(_medecineRespawnTime);
        int spawnPointsMaxIndex = _spawnPoints.Length;
        int spawmPointsMinIndex = 0;
        _isSpawning = true;

        while (_isSpawning)
        {
            int index = Random.Range(spawmPointsMinIndex, spawnPointsMaxIndex);
            Instantiate(_medecine.gameObject, _spawnPoints[index].transform);
            yield return respawnTime;
        }
    }
}
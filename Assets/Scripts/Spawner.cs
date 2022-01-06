using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] protected float _secondsBetweenSpawn;
    [SerializeField] protected Timer _timer;

    private int _spawnPointNumber;
    protected float _elapsedTime = 0;

    protected void SetSpawnPoint()
    {
        _spawnPointNumber = Random.Range(0, _spawnPoints.Length);
    }

    protected void InstantiateItem()
    {
        Instantiate(_itemPrefab, _spawnPoints[_spawnPointNumber].position, Quaternion.identity);
    }
}

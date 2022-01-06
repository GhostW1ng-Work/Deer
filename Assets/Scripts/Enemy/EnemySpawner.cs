using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : Spawner
{
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            _elapsedTime = 0;
            SetSpawnPoint();
            InstantiateItem();
        }

        if (_timer.CurrentTime >= 10)
        {
            _secondsBetweenSpawn = 3;
        }

        if (_timer.CurrentTime >= 30)
        {
            _secondsBetweenSpawn = 1;
        }

        if (_timer.CurrentTime >= 50)
        {
            _secondsBetweenSpawn = 0.5f;
        }

        if(_timer.CurrentTime >= 60)
        {
            _secondsBetweenSpawn = 0.3f;
        }

        if (_timer.CurrentTime >= 70)
        {
            _secondsBetweenSpawn = 0.2f;
        }
    }
}

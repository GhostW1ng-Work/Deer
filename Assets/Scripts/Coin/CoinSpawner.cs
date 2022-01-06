using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _secondsBetweenSpawn)
        {
            _elapsedTime = 0;
            SetSpawnPoint();
            InstantiateItem();  
        }

        if (_timer.CurrentTime >= 2)
            _secondsBetweenSpawn = 10;
    }
}

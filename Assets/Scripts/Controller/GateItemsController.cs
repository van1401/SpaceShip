using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class GateItemsController : GateController
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CalculateWave();
    }

    public override void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomItems = currrentWave.typeOfVariant[Random.Range(0, currrentWave.typeOfVariant.Length)];
            Transform randomPoint = _gate[Random.Range(0, _gate.Length)];
            //SmartPool.Instance.Spawn(randomItems, randomPoint.transform.position, transform.rotation);
            Instantiate(randomItems, randomPoint.transform.position, transform.rotation);
            currrentWave.spawnNumber--;
            nextSpawnTime = Time.time + currrentWave.spawnInterval;
            if (currrentWave.spawnNumber == 0)
            {
                canSpawn = false;
            }
        }
    }

    public override void CalculateWave()
    {
        currrentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
        {
            currentWaveNumber++;
            canSpawn = true;
        }
    }
}

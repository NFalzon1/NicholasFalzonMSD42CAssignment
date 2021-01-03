using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool looping = false;

    //wave always starting from Wave 0
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            //start coroutine that spawns all waves
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); //while (looping == true)
    }

    // Update is called once per frame
    void Update()
    {

    }

    //when calling Coroutine, specify which Wave we need to spawn enemies from
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveToSpawn)
    {
        //loop for spawn all enemies in wave
        for(int enemyCount = 1; enemyCount <=waveToSpawn.GetNumberOfEnemies(); enemyCount++)
        {
            //spawn the enemy from waveConfig at the position specified by waveConfig waypoints
            var newEnemy = Instantiate(
                            waveToSpawn.GetEnemyPrefab(),
                            waveToSpawn.GetWaypoints()[0].transform.position,
                            Quaternion.identity);
            
            //the wave will be selected from here and the enemy applied to it
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveToSpawn);

            //wait timeBetweenSpawns before spawning another enemy
            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
        
    }

    private IEnumerator SpawnAllWaves()
    {
        //loop all waves
        foreach(WaveConfig currentWave in waveConfigList)
        {
            //wait for all enemies to spawn before going to the next wave
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
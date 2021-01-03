using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    //the enemy that will spawn in this wave
    [SerializeField] GameObject enemyPrefab;

    //the path that the wave will follow
    [SerializeField] GameObject pathPrefab;

    //time between each enemy Spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of enemies in the Wave
    [SerializeField] int numberOfEnemies = 1;

    //the speed of the enemy
    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        //each wave can have different waypoints
        var waveWayPoints = new List<Transform>();

        //access pathPrefab and for each child
        //add it to the List waveWayPoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }

    public GameObject GetPathPrefab()
    {
        return pathPrefab;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
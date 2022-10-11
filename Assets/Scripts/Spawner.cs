using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePatterns;
    private float _timebetweenSpawns;
    private float startTimeBetweenSpawn = 3;

    private float _maximumSpawnTime = 2;
    [SerializeField] private float _decreasingTime = 0.01f;
    private float _minimumTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeSpeed", 0, 10);
    }

    // Spawning formations
    void Update()
    {
        if(UI.hasGameBegan == true)
        {
            if (_timebetweenSpawns <= 0)
            {
                int rand = Random.Range(0, _obstaclePatterns.Length);
                Instantiate(_obstaclePatterns[rand], transform.position, Quaternion.identity);
                _timebetweenSpawns = startTimeBetweenSpawn;
                if(_maximumSpawnTime > _minimumTime)
                {
                    _maximumSpawnTime -= _decreasingTime;
                } 
            }
            else
            {
                _timebetweenSpawns -= Time.deltaTime;
            }
        }
    }

    // Changes speed of formation spawning every 10 seconds
    void ChangeSpeed()
    {
        if(UI.hasGameBegan == true)
        {
            startTimeBetweenSpawn = Random.Range(0.75f, _maximumSpawnTime);
        }     
    }
}

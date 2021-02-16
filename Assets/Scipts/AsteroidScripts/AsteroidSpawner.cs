using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 size;
    [SerializeField] private float spawnRate = 600;
    [SerializeField] private GameObject asteroidModel;
    [SerializeField] private GameObject asteroidGroup;

    private float nextSpawn = 0;
    private bool _isSpawning = false;
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,1,0,0.5f);
        Gizmos.DrawCube(transform.position, size);
    }
    
    private void OnEnable()
    {
        GameManager.GameStartedEvent += ToggleSpawnStatus;
        GameManager.GameEndedEvent += ToggleSpawnStatus;
    }

    private void OnDisable()
    {
        GameManager.GameStartedEvent -= ToggleSpawnStatus;
        GameManager.GameEndedEvent -= ToggleSpawnStatus;
    }

    private void Update()
    {
        if (Time.time > nextSpawn && _isSpawning)
        {
            nextSpawn = Time.time + spawnRate;
            
            SpawnAsteroid();    
        }
    }

    private void SpawnAsteroid()
    {
        Vector3 spawnPoint = transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2), 
            Random.Range(-size.z / 2, size.z / 2));

        //Quaternion asteroidRotation = Quaternion.Euler(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360));
        Quaternion asteroidRotation = Quaternion.identity;
        
        GameObject asteroid = Instantiate(asteroidModel, spawnPoint, asteroidRotation);
        
        asteroid.transform.SetParent(asteroidGroup.transform);
    }

    public void ToggleSpawnStatus()
    {
        _isSpawning = !_isSpawning;
    }
}

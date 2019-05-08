using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsRespawner : MonoBehaviour
{
    public GameObject asteroidsPrefab;
    public float spawnDelay = 50f;
    public float spawnTime = 15f;
    public Transform[] spawnPoints;  // An array of the spawn points this enemy can spawn from.

    private bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        //asteroidsPrefab = Resources.Load("Asteroids") as GameObject;
        InvokeRepeating("Respawn", spawnTime, spawnTime);
    }

    void Respawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(asteroidsPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        if (stopSpawning)
        {
            CancelInvoke("Respawn");
        }
    }

}
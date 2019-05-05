using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsFormation : MonoBehaviour
{
    public GameObject asteroidsPrefab;
    public float spawnDelay = 0.5f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Spawing only one enemy at a time
    void asteroidsSpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject asteroids = Instantiate(asteroidsPrefab, freePosition.position, Quaternion.identity) as GameObject;
            asteroids.transform.parent = freePosition;
        }
        if (NextFreePosition())
        {
            Invoke("asteroidsSpawnUntilFull", spawnDelay);
        }
    }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    bool AllMemebersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        transform.position = startPosition;
        transform.rotation = startRotation;
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (AllMemebersDead())
        {
            asteroidsSpawnUntilFull();
        }
    }
}

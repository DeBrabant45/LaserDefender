using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{  
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 1f;
    public float spawnDelay = 0.5f;

    private bool movingRight = false;
    private float xMin;
    private float xMax;
    private Vector3 startPosition;
    private Quaternion startRotation;

    // Use this for initialization
    void Start ()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xMax = rightBoundary.x;
        xMin = leftBoundary.x;
        enemySpawnUntilFull();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // What Respawns the enemy after count hit 0
    void enemySpawn()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    // Spawing only one enemy at a time
    void enemySpawnUntilFull ()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition())
        {
            Invoke("enemySpawnUntilFull", spawnDelay);
        }
    }


    // Enemy Movement
    void enemyMovement()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);
        if (leftEdgeOfFormation < xMin)
        {
            movingRight = true;
        }
        else if (rightEdgeOfFormation > xMax)
        {
            movingRight = false;
        }
        //Setting the formation to fall to the earth
        transform.position += Vector3.down * speed * Time.deltaTime / 15;
    }


    public void OnDrawGizmos ()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
	
	// Update is called once per frame
	void Update ()
    {
        enemyMovement();
        if(AllMemebersDead())
        {
            enemySpawnUntilFull();
        }
    }


    Transform NextFreePosition ()
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

    // Checking Enemy count
    bool AllMemebersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if(childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        transform.position = startPosition;
        transform.rotation = startRotation;
        return true;
    }
}

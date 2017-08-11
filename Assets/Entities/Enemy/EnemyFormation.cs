using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    public float health = 200;
    public GameObject projectile;
    public float projectileSpeed;
    public int scoreValue = 150;
    private float fireRate = 0.2f;
    private ScoreKeeper scoreKeeper;


    void Start ()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }
	
    
    void enemyFire()
    {
        //Setting a offset so enemy doesn't shoot it's self
        Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -projectileSpeed, 0);
    }

    // Enemy taking damage from player
    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);
            }
            Debug.Log("Hit by missle");
        }
    }

    void Update ()
    {
        // Setting a Random enemy shot
        float probability = Time.deltaTime * fireRate;
        if (Random.value < probability)
        {
            enemyFire();
        }
    }
	

}

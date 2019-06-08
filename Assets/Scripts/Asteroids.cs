using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float damage = 100f;
    private float health = 100f;
    private ScoreKeeper scoreKeeper;
    private int scoreValue = 50;

    public AudioClip deathSound;
    public GameObject DustParticals;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();  
    }

    // Player taking damage from enemy
    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        float delayTimer = 8f;
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
        GameObject dustParticals = Instantiate(DustParticals, transform.position, Quaternion.identity) as GameObject;
        Destroy(dustParticals, delayTimer);
        scoreKeeper.Score(scoreValue);
        // Every time a asteriod is destoryed add a count to the post Level counter
        AsteriodsDestroyedCounter.asteriodKillCount++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

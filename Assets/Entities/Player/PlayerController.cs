using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float projectileSpeed;
    public float fireRate = 0.2f;
    public GameObject projectile;
    public GameObject DeathParticls;
    public GameObject[] ships = new GameObject[3];

    public AudioClip fireSound;
    public AudioClip deathSound;
    Vector2 movement = new Vector2();
    Rigidbody2D rb2D;

    public float health = 300;
    private float padding = 1.0f;
    private float xMin, xMax, yMin, yMax;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        Vector3 topmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 downmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;
        yMin = topmost.y + padding;
        yMax = downmost.y - padding;
    }

    void Fire()
    {
        //Setting a offset so player doesn't shoot himself
        Vector3 offSet = transform.position + new Vector3(0, 1, 0);
        GameObject beam = Instantiate(projectile, offSet, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);

    }

    void PlayerMoveSet()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb2D.velocity = movement * speed / 2;

        // Restrict the player to the game space
        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float newY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    void PlayerShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("Fire", 0.00001f, fireRate / 0.5f);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("Fire");
        }
    }

    // Player taking damage from enemy
    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        Asteroids asteroids = collider.gameObject.GetComponent<Asteroids>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
        }
        if(asteroids)
        {
            health -= asteroids.damage;
            asteroids.Die();
        }
        if (health <= 0)
        {
            Die();
        }
    }

    void HealthBar()
    {
        for(int i = 0; i < ships.Length; i++)
        {
            if(health >= 300)
                health = 300;
            switch(health)
            {
                case 300:
                    ships[i].gameObject.SetActive(true);
                    break;
                case 200:
                    ships[2].gameObject.SetActive(false);
                    break;
                case 100:
                    ships[1].gameObject.SetActive(false);
                    ships[2].gameObject.SetActive(false);
                    break;
                case 0:
                    ships[i].gameObject.SetActive(false);
                    break;
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
        GameObject deathParticle = Instantiate(DeathParticls, transform.position, Quaternion.identity) as GameObject;
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel(5);
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoveSet();
        PlayerShooting();
        HealthBar();
    }

}

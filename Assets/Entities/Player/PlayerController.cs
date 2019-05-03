using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    public float projectileSpeed;
    public float fireRate = 0.2f;
    public GameObject projectile;
    public GameObject DeathParticls;
    public GameObject ships1, ships2, ships3;


    public AudioClip fireSound;
    public AudioClip deathSound;

    private float health = 300;
    private float padding = 1.0f;
    private float xMin;
    private float xMax;

    // Use this for initialization
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;

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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(+speed * Time.deltaTime, 0, 0);
        }

        // Restrict the player to the game space
        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void PlayerShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.00001f, fireRate / 0.5f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
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

    void HealthBar()
    {
        if (health >= 300)
            health = 300;
        switch(health)
        {
            case 300:
                ships1.gameObject.SetActive(true);
                ships2.gameObject.SetActive(true);
                ships3.gameObject.SetActive(true);
                break;
            case 200:
                ships1.gameObject.SetActive(true);
                ships2.gameObject.SetActive(true);
                ships3.gameObject.SetActive(false);
                break;
            case 100:
                ships1.gameObject.SetActive(true);
                ships2.gameObject.SetActive(false);
                ships3.gameObject.SetActive(false);
                break;
            case 0:
                ships1.gameObject.SetActive(false);
                ships2.gameObject.SetActive(false);
                ships3.gameObject.SetActive(false);
                break;
        }
    }

    void Die()
    {
        Destroy(gameObject);
        GameObject deathParticle = Instantiate(DeathParticls, transform.position, Quaternion.identity) as GameObject;
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("Win Screen");
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveSet();
        PlayerShooting();
        HealthBar();
    }

}

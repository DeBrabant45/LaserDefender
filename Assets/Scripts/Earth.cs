using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyFormation enemy = collider.gameObject.GetComponent<EnemyFormation>();
        if (enemy)
        {
            LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            man.LoadLevel(5);
        }
    }
}

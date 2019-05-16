using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationSpawner : MonoBehaviour
{
    public GameObject[] enemyFormation;
    private GameObject newFormation;
    private FormationController foe;
    bool formationChange;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFormation();
        foe = newFormation.GetComponent<FormationController>();
    }

    public void SpawnFormation()
    {
        int spawn = Random.Range(0, enemyFormation.Length);
        newFormation = Instantiate(enemyFormation[spawn], transform.position, Quaternion.identity) as GameObject;
    }

    void ChangeFormation()
    {
        if (LevelTimer.levelTimer <= 15 && !formationChange && foe.AllMemebersDead() == true)
        {
            formationChange = true;
            Destroy(newFormation);
        }

        if (newFormation == null)
        {
            SpawnFormation();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeFormation();
    }
}

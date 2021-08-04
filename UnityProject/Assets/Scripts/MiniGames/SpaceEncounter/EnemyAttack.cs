using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject missile;
    public ParticleSystem boom;

    public int time_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        boom.Stop();
    }

    void FixedUpdate()
    {
        if (time_count % 200 == 1 && SpaceEncounterData.enemyHealth > 0)
        {
            missile.transform.position = transform.position;
            Instantiate(missile);
        }

        time_count++;

        if (SpaceEncounterData.enemyHealth > 0)
        {
            SpaceEncounterData.enemyHealth -= 0.1f;
        }
        else
        {
            SpaceEncounterData.enemyHealth = 0;
            boom.Play();
        }
    }
}

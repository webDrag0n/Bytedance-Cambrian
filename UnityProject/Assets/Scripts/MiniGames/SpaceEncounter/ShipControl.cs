using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public ParticleSystem boom;
    private void Start()
    {
        boom.Stop();
        SpaceEncounterData.playerTargetPosition = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, SpaceEncounterData.playerTargetPosition, 10*Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        SpaceEncounterData.playerHealth -= 10;
        boom.Play();
        Destroy(other.gameObject);
    }
    
}

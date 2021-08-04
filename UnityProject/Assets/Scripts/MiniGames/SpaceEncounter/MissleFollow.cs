using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleFollow : MonoBehaviour
{

    public Vector3 target;
    private Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Spaceship01").transform.position;
        direction = (target - transform.position).normalized;
        GetComponent<Rigidbody>().AddForce(direction * 600);
    }

}

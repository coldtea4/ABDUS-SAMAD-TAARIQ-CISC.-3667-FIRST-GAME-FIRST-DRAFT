using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinSpawn : MonoBehaviour
{
    [SerializeField] GameObject pin;
    [SerializeField] float spawnCD;
    private float lastSpawn;

    void Start()
    {
        lastSpawn = -spawnCD;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= lastSpawn + spawnCD)
        {
            Instantiate(pin, transform.position, Quaternion.Euler(0, 0, 90));
            lastSpawn = Time.time;
        }
    }
}

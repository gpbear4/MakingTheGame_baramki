﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnLocation = new Vector3(30, 0, 0);
    private float initalWait = 2;
    private float periodRepeat = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", initalWait, periodRepeat);
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnLocation, obstaclePrefab.transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject bgCratePrefab;
    private Vector3 spawnLocation = new Vector3(30, 0, 0);
    private float initalWait = 2;
    private float periodRepeat = 2;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", initalWait, periodRepeat);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        int bgBoxCount = 20;
        float bgWidth = GameObject.Find("Background").GetComponent<BoxCollider>().size.x;
        float spacing = bgWidth / bgBoxCount;

        for (int count = 0; count < bgBoxCount; count++)
        {
            Debug.Log(count * spacing);
            Instantiate(bgCratePrefab, new Vector3(count * spacing, 0, 4.15f), bgCratePrefab.transform.rotation);
        }
    }

    void Update()
    {

    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        if (playerController.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnLocation, obstaclePrefab.transform.rotation);
        }
    }
}

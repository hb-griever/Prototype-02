using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private float spawnInterval;
    private float deltaSpawnInterval = 0.01f;

    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            // Instead of destroying the projectile when it leaves the screen
            //Destroy(gameObject);

            // Just deactivate it
            gameObject.SetActive(false);

        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);

            spawnInterval = spawnManager.spawnInterval;
            spawnInterval -= deltaSpawnInterval;
            spawnManager.spawnInterval = spawnInterval;
        }

    }
}

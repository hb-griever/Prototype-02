using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 20.0f;
    private float xRange = 14;

    public AudioClip throwSound;
    private AudioSource playerAudio;

    public GameObject projectilePrefab;

    private ScoreManager scoreManager;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // while (scoreManager.isGameActive)
        // {
            // Check for left and right bounds
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            // Player movement left to right
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                // No longer necessary to Instantiate prefabs
                // Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

                // Get an object object from the pool
                GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
                if (pooledProjectile != null)
                {
                    pooledProjectile.SetActive(true); // activate it
                    pooledProjectile.transform.position = transform.position + new Vector3(0, 0.25f, 0); // position it at player and up a little

                    playerAudio.PlayOneShot(throwSound, 1.0f);
                }
            }
        // }
    }
}

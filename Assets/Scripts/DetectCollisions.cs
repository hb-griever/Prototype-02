using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private float chickScale = 1;
    private float brownChickenScale = 1;
    private float whiteChickenScale = 1;
    private float brownRoosterScale = 1;
    private float scaleIncrease = 0.5f;

    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        //play hit sound
        spawnManager.playImpact = true;

        // Deactivate the wine and destroy the animal
        other.gameObject.SetActive(false);
        Destroy(gameObject);        

        if (gameObject.CompareTag("Chick"))
        {
            chickScale = spawnManager.chickScaleMulitplier;
            chickScale += scaleIncrease;
            spawnManager.chickScaleMulitplier = chickScale;
        }
        else if (gameObject.CompareTag("BrownChicken"))
        {
            brownChickenScale = spawnManager.chickenBrownScaleMulitplier;
            brownChickenScale += scaleIncrease;
            spawnManager.chickenBrownScaleMulitplier = brownChickenScale;
        }
        else if (gameObject.CompareTag("WhiteChicken"))
        {
            whiteChickenScale = spawnManager.chickenWhiteScaleMulitplier;
            whiteChickenScale += scaleIncrease;
            spawnManager.chickenWhiteScaleMulitplier = whiteChickenScale;
        }
        else if (gameObject.CompareTag("BrownRooster"))
        {
            brownRoosterScale = spawnManager.roosterBrownScaleMulitplier;
            brownRoosterScale += scaleIncrease;
            spawnManager.roosterBrownScaleMulitplier = brownRoosterScale;
        }
    }
}

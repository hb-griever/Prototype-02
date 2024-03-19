using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private int rangeMin = -14;
    private int rangeMax = 14;

    public float spawnInterval = 1.5f;
    private float chickenWhiteScale;
    private float chickenBrownScale;
    private float chickScale;
    private float roosterBrownScale;
    
    public int chickenWhiteScaleMulitplier = 1;
    public int chickenBrownScaleMulitplier = 1;
    public int chickScaleMulitplier = 1;
    public int roosterBrownScaleMulitplier = 1;

    public Vector3 scaleChange;

    private float time;
    private float minSpawnInterval = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        chickenWhiteScale = 0.09f;
        chickenBrownScale = 0.09f;
        chickScale = 0.09f;
        roosterBrownScale = 0.10f;
    }
    // Update is called once per frame
    void Update()
    {  
        time = time + Time.deltaTime;
            
        if (time > spawnInterval && spawnInterval >= minSpawnInterval)
        {
            SpawnRandomAnimal();
            time = 0;
        } else if (spawnInterval < minSpawnInterval)
        {
            spawnInterval = minSpawnInterval;
        }
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int spawnLocation = Random.Range(rangeMin, rangeMax);

        ScaleMultiplier();

        animalPrefabs[0].transform.localScale = new Vector3(chickenWhiteScale, chickenWhiteScale, chickenWhiteScale);
        animalPrefabs[1].transform.localScale = new Vector3(chickenBrownScale, chickenBrownScale, chickenBrownScale);
        animalPrefabs[2].transform.localScale = new Vector3(chickScale, chickScale, chickScale);
        animalPrefabs[3].transform.localScale = new Vector3(roosterBrownScale, roosterBrownScale, roosterBrownScale);

        Instantiate(animalPrefabs[animalIndex], new Vector3(spawnLocation, 0, 30), animalPrefabs[animalIndex].transform.rotation);
    }

    void ScaleMultiplier()
    {
        chickenWhiteScale = chickenWhiteScaleMulitplier * 0.09f;
        chickenBrownScale = chickenBrownScaleMulitplier * 0.09f;
        chickScale = chickScaleMulitplier * 0.09f;
        roosterBrownScale = chickScaleMulitplier * 0.10f;
    }


}

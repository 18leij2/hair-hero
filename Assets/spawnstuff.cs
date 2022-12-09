using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnstuff : MonoBehaviour
{
    public GameObject zombiePrefab;
    public GameObject healthPrefab;
    public float zombieCounter;
    public float healthCounter;
    private Vector2[] ZombPositions;
    public int waveZombies = 8;
    public int waveIncrement = 2;
    public int wave = 1;
    private int zombiesSpawnedThisWave = 0;
    public Manager manager;
    public GameObject hairgelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        zombieCounter = 0f;
        healthCounter = 0f;
        InvokeRepeating("spawnZombies", 1.0f, 1.0f);
        InvokeRepeating("spawnHealth", 1.0f, 1.0f);

        manager.SetWave(wave);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnZombies()
    {
        Vector2[] ZombPositions = new[] 
        {
            new Vector2(Random.Range(-8, -4), Random.Range(0, 15)),
            new Vector2(Random.Range(74, 76), Random.Range(3, 9)),
            new Vector2(Random.Range(26, 33), Random.Range(13, 17))
        };

        if (zombieCounter < 10f && zombiesSpawnedThisWave < (waveZombies + (waveIncrement * (wave - 1))))
        {
            Instantiate(zombiePrefab, ZombPositions[Random.Range(0, ZombPositions.Length)], zombiePrefab.transform.rotation);
            zombieCounter += 1f;
            zombiesSpawnedThisWave += 1;
        }
    }

    void spawnHealth()
    {
        if (healthCounter < 2f)
        {
            Instantiate(healthPrefab, new Vector3(Random.Range(-8f,76f),Random.Range(-3f,9f),0f), healthPrefab.transform.rotation);
            healthCounter += 1f;
        }
    }

    public void RemoveZombie(Transform location)
    {
        zombieCounter -= 1f;
        if (zombieCounter == 0 && zombiesSpawnedThisWave >= (waveZombies + (waveIncrement * (wave - 1))))
        {
            Instantiate(hairgelPrefab, location.position, location.rotation);
        }
    }

    public void NextWave()
    {
        wave += 1;
        zombiesSpawnedThisWave = 0;
        manager.SetWave(wave);
    }
}

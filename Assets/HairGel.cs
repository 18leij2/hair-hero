using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairGel : MonoBehaviour
{
    public spawnstuff spawner;
    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawn Manager").GetComponent<spawnstuff>();
        manager = GameObject.Find("Game Manager").GetComponent<Manager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            manager.AddScore(100);
            spawner.NextWave();
            Destroy(gameObject);
        }
    }
}

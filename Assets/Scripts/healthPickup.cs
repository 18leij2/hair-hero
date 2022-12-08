using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    public GameObject spawnManager;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager");
        player = GameObject.Find("Player");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<health>().pHealth += 0.25f;
            spawnManager.GetComponent<spawnstuff>().healthCounter -= 1f;
            Destroy(gameObject);
        }
    }
}

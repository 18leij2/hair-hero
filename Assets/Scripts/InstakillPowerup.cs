using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstakillPowerup : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponentInChildren<shooting>().Instakill(5f);
            Destroy(gameObject);
        }
    }
}

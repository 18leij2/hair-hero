using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float pHealth = 1f;
    public float damageCounter;
    private bool zoneDamage = false;
    public GameObject shieldPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       dangerZone();
    }

    void dangerZone()
    {
        if (zoneDamage)
        {
            pHealth -= (0.1f * Time.deltaTime);
        }

        if (pHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "danger" && !shieldPrefab.active)
        {
           zoneDamage = true;
        }

        if (col.gameObject.tag == "bullet")
        {
           //pHealth -= damageCounter;
           Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Enemy" && !gameObject.GetComponent<shield>().shieldActive)
        {
            zoneDamage = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "danger")
        {
           zoneDamage = false; 
        }
        if (col.gameObject.tag == "Enemy")
        {
            zoneDamage = false;
        }
    }
}

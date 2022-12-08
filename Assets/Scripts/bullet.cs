using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forceSpeed;
    public bool instakill = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * forceSpeed);
        rb.velocity = forceSpeed * (rb.velocity.normalized);
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "danger")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Enemy")
        {
            if (instakill)
            {
                col.gameObject.GetComponent<hunt>().health = -10000;
            }
            Destroy(gameObject);
        }
    }
}

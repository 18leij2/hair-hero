using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hunt : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject spawnManager;
    public GameObject target;
    public float health;
    public float zombieSpeed;
    private bool zoneDamage = false;
    public bool chase;

    // Start is called before the first frame update
    void Start()
    {
        health = 1f;
        chase = false;
        zombieSpeed = Random.Range(1f, 4f);
        transform.localScale = new Vector2(2f / zombieSpeed, 2f / zombieSpeed);
        rb.mass = 100 * (2f / zombieSpeed);
        spawnManager = GameObject.Find("Spawn Manager");
        target = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        Movement();
        zombHP();
        changeDirection();
    }

    void zombHP()
    {
        if (zoneDamage)
        {
            health -= (Time.deltaTime);
        }

        if (health <= 0f)
        {
            spawnManager.GetComponent<spawnstuff>().zombieCounter -= 1f;
            Destroy(gameObject);
        }

        if (health < 1f && !zoneDamage)
        {
            StartCoroutine("Regen", 3f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "danger")
        {
            rb.velocity = new Vector2(rb.velocity.x, Random.Range(6f, 9f));
            zoneDamage = true;
            health -= 0.15f;
        }
        if (col.gameObject.tag == "wall")
        {
            rb.velocity = new Vector2(rb.velocity.x, Random.Range(6f, 9f));
        }
        if (col.gameObject.tag == "bullet")
        {
            health -= (target.GetComponent<health>().damageCounter - (rb.mass / 2800));
            StopCoroutine("Regen");
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Enemy")
        {
            rb.velocity = new Vector2(rb.velocity.x, Random.Range(3f, 6f));
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "bounce")
        {
            rb.velocity = new Vector2(rb.velocity.x, 18f);
        }

        if (col.gameObject.tag == "danger")
        {
            zoneDamage = false;
        }
    }

    void changeDirection()
    {
        if (chase == false)
        {
            if (Random.Range(1,1000) >= 990)
            {
                zombieSpeed *= -1;
            }
        }
    }

    void Movement()
    {
        if (Vector2.Distance(target.transform.position, transform.position) <= 15f)
        {
            chase = true;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, (2 * zombieSpeed) * Time.deltaTime);
        }
        else
        {
            chase = false;
            transform.position += new Vector3(zombieSpeed * Time.deltaTime, 0, 0);
        }
    }

    IEnumerator Regen(float duration)
    {
        yield return new WaitForSeconds(duration);
        health += (rb.mass / 600) * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shield : MonoBehaviour
{
    public GameObject shieldPrefab;
    public bool charged = true;
    public bool shieldActive = false;
    public Text shieldtxt;
    public float blastRadius;
    public float blastForce;
    public float stunDuration;

    // Start is called before the first frame update
    void Start()
    {
        shieldtxt.text = "SHIELD OFF";
        shieldPrefab.GetComponent<SpriteRenderer>().enabled = false;
        shieldPrefab.GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown("s") && charged)
          {
            Blast();
            StartCoroutine(shieldAct(3f));
          }
    }

    void Blast()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, blastRadius, LayerMask.GetMask("Enemy"));
        foreach (Collider2D c in hits)
        {
            c.GetComponent<hunt>().Stun(stunDuration);
            c.GetComponent<Rigidbody2D>().velocity = ((c.transform.position - transform.position).normalized * blastForce);
        }
    }

    IEnumerator shieldAct(float duration)
    {
        shieldActive = true;
        shieldPrefab.active = true;
        shieldPrefab.GetComponent<SpriteRenderer>().enabled = true;
        shieldPrefab.GetComponent<CircleCollider2D>().enabled = true;
        shieldtxt.text = "SHIELD ACTIVE";
        yield return new WaitForSeconds(duration);
        shieldPrefab.GetComponent<SpriteRenderer>().enabled = false;
        shieldPrefab.GetComponent<CircleCollider2D>().enabled = false;
        shieldActive = false;
        shieldPrefab.active = false;
        shieldtxt.text = "SHIELD OFF";
        StartCoroutine(shieldCharge(5f));
    }

    IEnumerator shieldCharge(float duration)
    {
        charged = false;
        shieldtxt.text = "CHARGING...";
        yield return new WaitForSeconds(duration);
        charged = true;
        shieldtxt.text = "SHIELD READY";
    }


}

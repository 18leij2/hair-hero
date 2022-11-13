using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrent : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    private float turrentRange;
    private float Timer = 1f;
    private float rotateSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<health>().damageCounter = 0.15f;
        bulletPrefab.transform.localScale = new Vector3(10f, 10f, 0f);
        bulletPrefab.GetComponent<bullet>().forceSpeed = 10f;
        turrentRange = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= turrentRange)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0f)
            {
                Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                Timer = 1f;
            }

            float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}

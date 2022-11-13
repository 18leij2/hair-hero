using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    public float angle;
    public float pistolammo;
    public SpriteRenderer weaponSprite;
    public GameObject shieldPrefab;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public Text ammotxt;
    public Texture2D crosshair;
    private Vector2 cursorHotspot;
    public Sprite[] spriteArray;
    private float Timer = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        cursorHotspot = new Vector2(crosshair.width / 2, crosshair.height / 2);
        Cursor.SetCursor(crosshair, cursorHotspot, CursorMode.ForceSoftware);
        ammotxt.text = pistolammo.ToString();
        weaponSprite.sprite = spriteArray[0];
        pistolammo = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Direction();
        ChangeWeapon();
        Shoot();
    }

    void Shoot()
    {
        if (weaponSprite.sprite == spriteArray[0])
        {
            player.GetComponent<health>().damageCounter = 0.1f;
            bulletPrefab.transform.localScale = new Vector3(1f, 1f, 0f);
            bulletPrefab.GetComponent<bullet>().forceSpeed = 20f;
            if (Input.GetMouseButtonDown(0) && shieldPrefab.active == false && pistolammo >= 1f)
            {
                pistolammo -= 1f;
                Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                ammotxt.text = pistolammo.ToString();

            }
            if (Input.GetKeyDown("r"))
            {
                StartCoroutine(pistolReload(2f));
            }
        }
        if (weaponSprite.sprite == spriteArray[1])
        {
            player.GetComponent<health>().damageCounter = 0.15f;
            bulletPrefab.transform.localScale = new Vector3(1.5f, 1.5f, 0f);
            bulletPrefab.GetComponent<bullet>().forceSpeed = 30f;
            if (Input.GetMouseButtonDown(0) && shieldPrefab.active == false && pistolammo >= 1f)
            {
                pistolammo -= 1f;
                Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation * Quaternion.Euler(0, 0f, 60f));
                Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation * Quaternion.Euler(0, 0f, -60f));
                ammotxt.text = pistolammo.ToString();
            }
            if (Input.GetKeyDown("r"))
            {
                StartCoroutine(shottyReload(3f));
            }
        }
        if (weaponSprite.sprite == spriteArray[2])
        {
            player.GetComponent<health>().damageCounter = 0.05f;
            bulletPrefab.transform.localScale = new Vector3(0.75f, 0.75f, 0f);
            bulletPrefab.GetComponent<bullet>().forceSpeed = 50f;
            if (Input.GetMouseButton(0) && shieldPrefab.active == false && pistolammo >= 1f)
            {
                Timer -= Time.deltaTime;
                if (Timer <= 0f)
                {
                    pistolammo -= 1f;
                    Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                    ammotxt.text = pistolammo.ToString();
                    Timer = 0.15f;
                }
            }
            if (Input.GetKeyDown("r"))
            {
                StartCoroutine(subReload(4f));
            }
        }
        if (weaponSprite.sprite == spriteArray[3])
        {
            player.GetComponent<health>().damageCounter = 0.075f;
            bulletPrefab.transform.localScale = new Vector3(1.25f, 1.25f, 0f);
            bulletPrefab.GetComponent<bullet>().forceSpeed = 40f;
            if (Input.GetMouseButton(0) && shieldPrefab.active == false && pistolammo >= 1f)
            {
                Timer -= Time.deltaTime;
                if (Timer <= 0f)
                {
                    pistolammo -= 1f;
                    Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                    ammotxt.text = pistolammo.ToString();
                    Timer = 0.25f;
                }

            }
            if (Input.GetKeyDown("r"))
            {
                StartCoroutine(akReload(3.5f));
            }
        }
        if (weaponSprite.sprite == spriteArray[4])
        {
            player.GetComponent<health>().damageCounter = 0.5f;
            bulletPrefab.transform.localScale = new Vector3(1f, 1f, 0f);
            bulletPrefab.GetComponent<bullet>().forceSpeed = 75f;
            if (Input.GetMouseButtonDown(0) && shieldPrefab.active == false && pistolammo >= 1f)
            {
                pistolammo -= 1f;
                Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                ammotxt.text = pistolammo.ToString();

            }
            if (Input.GetKeyDown("r"))
            {
                StartCoroutine(snipeReload(4f));
            }
        }
        if (weaponSprite.sprite == spriteArray[5])
        {
            player.GetComponent<health>().damageCounter = 0.75f;
            bulletPrefab.transform.localScale = new Vector3(3f, 3f, 0f);
            bulletPrefab.GetComponent<bullet>().forceSpeed = 10f;
            if (Input.GetMouseButtonDown(0) && shieldPrefab.active == false && pistolammo >= 1f)
            {
                pistolammo -= 1f;
                Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                ammotxt.text = pistolammo.ToString();

            }
            if (Input.GetKeyDown("r"))
            {
                StartCoroutine(rpgReload(5f));
            }
        }
    }
    void Direction()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Mathf.Abs(angle) >= 80f)
        {
            weaponSprite.flipY = true;
        }

        else
        {
            weaponSprite.flipY = false;
        }
    }

    IEnumerator pistolReload(float duration)
    {
        ammotxt.text = "Reloading...";
        yield return new WaitForSeconds(duration);
        pistolammo = 8f;
        ammotxt.text = pistolammo.ToString(); 
    }

    IEnumerator shottyReload(float duration)
    {
        ammotxt.text = "Reloading...";
        yield return new WaitForSeconds(duration);
        pistolammo = 3f;
        ammotxt.text = pistolammo.ToString();
    }

    IEnumerator subReload(float duration)
    {
        ammotxt.text = "Reloading...";
        yield return new WaitForSeconds(duration);
        pistolammo = 18f;
        ammotxt.text = pistolammo.ToString();
    }

    IEnumerator akReload(float duration)
    {
        ammotxt.text = "Reloading...";
        yield return new WaitForSeconds(duration);
        pistolammo = 12f;
        ammotxt.text = pistolammo.ToString();
    }

    IEnumerator snipeReload(float duration)
    {
        ammotxt.text = "Reloading...";
        yield return new WaitForSeconds(duration);
        pistolammo = 3f;
        ammotxt.text = pistolammo.ToString();
    }

    IEnumerator rpgReload(float duration)
    {
        ammotxt.text = "Reloading...";
        yield return new WaitForSeconds(duration);
        pistolammo = 2f;
        ammotxt.text = pistolammo.ToString();
    }

    void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSprite.sprite = spriteArray[0];
            pistolammo = 8f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponSprite.sprite = spriteArray[1];
            pistolammo = 3f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponSprite.sprite = spriteArray[2];
            pistolammo = 18f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weaponSprite.sprite = spriteArray[3];
            pistolammo = 12f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            weaponSprite.sprite = spriteArray[4];
            pistolammo = 3f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            weaponSprite.sprite = spriteArray[5];
            pistolammo = 2f;
        }
    }
}

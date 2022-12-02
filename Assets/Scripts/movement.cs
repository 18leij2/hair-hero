using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class movement : MonoBehaviour
{
    public GameObject weapon;
    public GameObject hBar;
    public GameObject pTag;
    public GameObject fPoint;
    public float moveSpeed = 10f;
    private float jumpSpeed = 4f;
    public float fuel = 1f;
    private bool onGround = false;
    public Rigidbody2D rb;
    public ParticleSystem particleFx;

    public Animator playerAnimator;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        var emission = particleFx.emission;
        emission.rateOverTime = 0;
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jetpack();
    }

    void Jetpack()
    {
        if (Input.GetKey("w") && fuel > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            fuel -= (0.5f *Time.deltaTime);
            var emission = particleFx.emission;
            emission.rateOverTime = 50;
            playerAnimator.SetBool("Jumping", true);
            isJumping = true;
        } else
        {
            var emission = particleFx.emission;
            emission.rateOverTime = 0;
            playerAnimator.SetBool("Jumping", false);
            isJumping = false;
        }

        if (onGround)
        {
            fuel += (0.5f * Time.deltaTime);
        }

        fuel = Mathf.Clamp(fuel, 0f, 1f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "danger")
        {
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }

    void Movement()
    {
        if (onGround && (Input.GetKey("a") || Input.GetKey("d")))
        {
            playerAnimator.SetBool("Running", true);
        }
        else
        {
            playerAnimator.SetBool("Running", false);
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        if (Mathf.Abs(weapon.GetComponent<shooting>().angle) >= 80f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            hBar.transform.localRotation = Quaternion.Euler(0, 0, 0);
            pTag.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        else
        {
            transform.localRotation = Quaternion.Euler(0, 180f, 0);
            hBar.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            pTag.transform.localRotation = Quaternion.Euler(0, 180f, 0);
        }
    }
}

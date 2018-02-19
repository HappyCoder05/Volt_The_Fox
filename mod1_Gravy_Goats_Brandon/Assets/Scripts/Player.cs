using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 5f; //limit speed
    public float speed = 150f; //speed of player
    public float jumpPower = 7f; //how high player jumps 
    public bool grounded; //check if player is grounded
    public Vector3 startPosition = new Vector2 (-4f, 3f);

    //stats
    public int curHealth;
    public int maxHealth = 5;

    private Rigidbody2D rb2d;
    private Animator anim;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        transform.position = startPosition;
        curHealth = maxHealth;
    }

    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetAxis("Horizontal") < -0.1f)//move left
        {
            transform.localScale = new Vector3(0.15f, 0.15f, 1);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)//move right
        {
            transform.localScale = new Vector3(-0.15f, 0.15f, 1);
        }

        if (Input.GetButtonDown("Jump") && grounded)//jump only when gorunded
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {
            Die();
        }
    }

    void FixedUpdate() //used for physics movement
    {
        float horz = Input.GetAxis("Horizontal"); //determine if left or rigth is pressed (-1 or +1)
        rb2d.AddForce((Vector2.right * speed) * horz); //move player if left or right is pressed

        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        //friction for no slip after walking
        rb2d.velocity = easeVelocity;
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        //limit speed of player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void Die()
    {
        //restart
        Application.LoadLevel(Application.loadedLevel);
    }
}

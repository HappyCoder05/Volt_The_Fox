﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 jump = new Vector2(0.0f, 10.0f);
    public float jumpForce = 15f;

    public Vector3 velocity = new Vector2(0, 0);
    public float speed = 2f;

    Rigidbody2D rb;
    SpriteRenderer mySpriteRenderer;
    bool grounded = true;
    //bool canMove = true;


    // Use this for initialization
    void Start()
    {
        //transform.position =  new Vector2(0, 0f);
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        //rb.position = new Vector2(1, 1); 
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("Collision with: "+  coll.gameObject.name);
        if (coll.gameObject.name == "end")
            Debug.Log("End");
        grounded = true;
        //canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f)));

        velocity = new Vector2(0, 0);

        //Move Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            mySpriteRenderer.flipX = true;
            velocity = new Vector2(-2f, 0);
        }
        //Move Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            mySpriteRenderer.flipX = false;
            velocity = new Vector2(2f, 0);
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            grounded = false;
            //canMove = false;
        }
        transform.position = transform.position + (velocity * speed * Time.deltaTime);

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    private Rigidbody2D platform_rb;
    private Vector2 starting_pos;
	

	void Start ()
    {
        platform_rb = GetComponent<Rigidbody2D>();
        starting_pos = transform.position;
	}
	
	
	void Update ()
    {
		if(transform.position.y < 0 && gameObject.name == "trap")
        {
            platform_rb.gravityScale = 0.0f;
            transform.position = starting_pos;
        }
        if(gameObject.name == "moving_platform")
        {
            if(transform.position.y < 2.0f)
            {
                platform_rb.gravityScale = -.75f;
            }
            else if(transform.position.y > 8.0f)
            {
                platform_rb.gravityScale = .75f;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(gameObject.name == "trap")
            platform_rb.gravityScale = 0.25f;
        //rigidbody.gravityScale = 0.1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Trap : MonoBehaviour {

    Rigidbody2D rb;
    private Player player;
    private SpriteRenderer tree_traps;
    Vector2 start_position;
	
	void Start () {
        tree_traps = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        tree_traps.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        start_position = rb.position;
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            tree_traps.enabled = true;
            rb.isKinematic = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            player.dead = true;
            rb.transform.position = start_position;
            rb.isKinematic = false;
        }

    }
    // Update is called once per frame
    void Update () {
	
	}
}

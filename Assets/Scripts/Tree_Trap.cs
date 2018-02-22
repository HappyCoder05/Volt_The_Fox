using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Trap : MonoBehaviour {

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name.Equals("player"))
            rb.isKinematic = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
            Debug.Log("got him");
            
    }
    // Update is called once per frame
    void Update () {
	
	}
}

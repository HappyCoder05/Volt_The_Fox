using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Vector3 velocity = new Vector2(0, 0);
    public float speed = 2f;

    // Use this for initialization
    void Start ()
    {
        transform.position =  new Vector2(0, -3f);
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        velocity = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
            velocity = new Vector2(-2f, 0);
        else if (Input.GetKey(KeyCode.RightArrow))
            velocity = new Vector2(2f, 0);
        if (Input.GetKey(KeyCode.Space))
            velocity = new Vector2(velocity.x, 5f);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            velocity = new Vector2(0, -5f);

        transform.position = transform.position + (velocity * speed * Time.deltaTime);

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D MyRigidBody;
    private Animator myAnimator;
    private bool facingRight;

    [SerializeField]
    private float movementSpeed;
	// Use this for initialization
	void Start () {
        facingRight = true;
        MyRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
     
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);
	}

    private void HandleMovement(float horizontal)
    {
        MyRigidBody.velocity = new Vector2(horizontal * movementSpeed, MyRigidBody.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }
    private void Flip(float horizontal)
    {
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 LineScale = transform.localScale;
            LineScale.x *= -1;
            transform.localScale = LineScale;
        }
    }
}

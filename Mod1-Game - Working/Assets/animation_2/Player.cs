using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D MyRigidBody;
    private Animator myAnimator;
    private bool facingRight;
    bool grounded = true;
    public float jumpForce = 15f;
    public Vector2 jump = new Vector2(0.0f, 10.0f);
    //[SerializeField]
    public float movementSpeed;


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

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            MyRigidBody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            grounded = false;

        }
        if(transform.position.y < 0)
        {

            Vector2 temp = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
            //Debug.Log(temp);
            transform.position = new Vector2(-2, 2);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Debug.Log("Collision with: "+  coll.gameObject.name);
        if (coll.gameObject.name == "end")
            Debug.Log("End of Level");
        grounded = true;
        //canMove = true;
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

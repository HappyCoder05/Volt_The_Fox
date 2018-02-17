using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    private Player player; //access variables in Player Script
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)//is grounded
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)//no longer grounded
    {
        player.grounded = false;
    }

    void OnTriggerStay2D(Collider2D col) //called when trigger stays in something fixes bug where gorunded did not get set to true sometimes
    {
        player.grounded = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {
    public Vector3 respawnPoint;

    private Player player; //access variables in Player Script

    void Start ()
    {
        player = gameObject.GetComponentInParent<Player>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        if (transform.position.y < 0)
        {
            transform.position = respawnPoint;
            player.curHealth--;
        }
    }
	
}

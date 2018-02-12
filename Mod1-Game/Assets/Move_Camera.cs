using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Camera : MonoBehaviour {

    Vector2 cam;
    // Use this for initialization
    void Start()
    {
        Debug.Log(Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth/2, Camera.main.pixelHeight/2)));
        cam = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > cam.x)
        {

            Vector2 temp = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(temp.x + 10f, temp.y, -10);
            cam = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));

        }
        /*
        else if (transform.position.x < cam.x - 10f)
        {
            Vector2 temp = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
            transform.position = new Vector2(temp.x + 1f, transform.position.y);
        }
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Camera : MonoBehaviour
{
    Vector2 cam;
    void Start()
    {
        //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth/2, Camera.main.pixelHeight/2)));
        //cam = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
        cam = Camera.main.transform.position;
    }

    void Update()
    {
        if (transform.position.x > cam.x + 8.5f)
        {

            Vector2 temp = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(temp.x + 18f, temp.y, -10);
            //cam = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
            cam = Camera.main.transform.position;
        }

        else if (transform.position.x < cam.x - 8.5f)
        {
            Vector2 temp = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
            transform.position = new Vector2(temp.x + 1f, transform.position.y);
        }

    }
}

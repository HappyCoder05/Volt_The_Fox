using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plummet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider is on trigger.");
        Vector3 velocity = new Vector2(0, -20f);

        transform.position = transform.position + (velocity * Time.deltaTime);

    }
}

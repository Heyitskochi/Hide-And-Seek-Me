using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingBehavior : MonoBehaviour
{
    private int timeLimit = 200;

    private void FixedUpdate()
    {
        if (timeLimit-- == 0)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class pingBehavior : MonoBehaviour
{
    private int timeLimit = 200;

    private GameObject Planet;
    private Rigidbody rb;
    float gravity = 10;

    private void FixedUpdate()
    {

        if (timeLimit-- == 0)
            Destroy(gameObject);
        if (Planet != null)
        {
            Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;
            rb.AddForce(gravDirection * -gravity);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.name);
    }
    public void setup(GameObject planet)
    {
        Planet = planet;
        rb = GetComponent<Rigidbody>();
    }
}

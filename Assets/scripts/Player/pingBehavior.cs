using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
//actually just the scanner(projectile) behavour
public class pingBehavior : MonoBehaviour
{
    private int timeLimit = 200;

    private GameObject Planet;
    private Rigidbody rb;
    private PhotonView PV;
    float gravity = 10;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
        if(!PV.IsMine)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

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
        if (other.tag != "Planet") return; // ignore if it is not planet
        Destroy(gameObject);

        GameObject effect = PhotonNetwork.Instantiate(Path.Combine("Prefab", "ping"), transform.position, Quaternion.identity, 0);

    }
    public void setup(GameObject planet)
    {
        Planet = planet;
        rb = GetComponent<Rigidbody>();
    }



    

}

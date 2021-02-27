using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingTriggered : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider[] scanned = Physics.OverlapSphere(transform.position, 2);
        foreach (Collider scannedItem in scanned)
        {
            Debug.Log(scannedItem.name);   
            if (scannedItem.tag == "Player")
            {
                if (!scannedItem.GetComponent<PhotonView>().IsMine)
                    scannedItem.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = true;
                
            }
        }
        Destroy(gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

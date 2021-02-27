using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using System.IO;

public class PlayerPing : MonoBehaviour
{
    #region variables
    //Networking
    private PhotonView PV;


    //firing
    public GameObject pingProjectile;
    [SerializeField]
    private float fireMult = 0.8f;
    private float currentFirePower = 0;
    [SerializeField]private float maxFirePower = 3;
    private float cooldown = 2;
    private float timeToFire;
    private bool fired = false;
    private Transform firePos;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        firePos = transform.Find("FirePosition");
    }

    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine) return; //return if it is not current player's unit
        if(!fired )
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                charge();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                fire();
            }
        }
        else
        {
            fired = Time.time < timeToFire;
        }
      

    }

    private void charge()
    {
        if(currentFirePower >= maxFirePower)
        {
            fire();
        }
        currentFirePower += Time.deltaTime;

        
    }

    private void fire()
    {
        
        GameObject scanner = Instantiate(pingProjectile, firePos.position, Quaternion.identity);
        scanner.GetComponent<Rigidbody>().AddForce(transform.forward * currentFirePower * fireMult);
        scanner.GetComponent<pingBehavior>().setup(GetComponent<TutorialPlayer>().Planet);
        fired = true;
        currentFirePower = 0;
        timeToFire = Time.time + cooldown;
    }
}

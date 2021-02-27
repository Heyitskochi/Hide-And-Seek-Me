﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TutorialPlayerPlaceholder : MonoBehaviour
{
 
    public GameObject Player;
    public GameObject Planet;
 
    // Update is called once per frame
    void Update()
    {
        //SMOOTH
 
        //POSITION
        transform.position = Vector3.Lerp(transform.position, Player.transform.position, 0.1f);

        //Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;
        Vector3 gravDirection = Player.transform.position - Planet.transform.position;
        //ROTATION
        //Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDirection) * transform.rotation;
        Quaternion toRotation = Quaternion.LookRotation(Player.transform.forward, gravDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.1f);
 
    }
 
 
    public void NewPlanet(GameObject newPlanet) {
 
        Planet = newPlanet;
    }
 
}
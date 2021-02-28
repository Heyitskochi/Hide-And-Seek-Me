using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TutorialPlayerPlaceholder : MonoBehaviour
{
 
    public GameObject Player;
    public GameObject Planet;
    public const float lerpAmount = 0.07f;
    // Update is called once per frame
    void Update()
    {
        //SMOOTH
 
        //POSITION
        transform.position = Vector3.Lerp(transform.position, Player.transform.position,lerpAmount);

        //Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;
        Vector3 gravDirection = Player.transform.position - Planet.transform.position;
        //ROTATION
        //Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDirection) * transform.rotation;
        Quaternion toRotation = Quaternion.LookRotation(Player.transform.forward, gravDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, lerpAmount);
 
    }
 
 
    public void NewPlanet(GameObject newPlanet) {
 
        Planet = newPlanet;
    }
 
}
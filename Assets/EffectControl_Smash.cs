using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl_Smash : MonoBehaviour
{
    ParticleSystem PS;
    // Start is called before the first frame update
    void Start()
    {
        PS = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            PS.Play(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chargeDisplay : MonoBehaviour
{
    private int chargeTime = 5;
    public Text chargeText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chargeText.text = "Charge Time"
    }
}

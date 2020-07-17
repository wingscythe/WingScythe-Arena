using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private int current_health = 10;
    public Text health_display;
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        health_display.text = "HP: " + current_health.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            current_health--;
        }
    }
}

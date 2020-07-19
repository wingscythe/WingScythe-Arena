using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Slider hp_slider;
    public float current_health;
    public Text health_display;
    public Animator anims;

    // Start is called before the first frame update
    void Start()
    {
    
    } 

    // Update is called once per frame
    void Update()
    {
        current_health = hp_slider.value;
        health_display.text = "HP: " + current_health.ToString() + " / " + hp_slider.maxValue;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hp_slider.value--;
        }
        anims.SetInteger("health", (int)current_health);
    }
}

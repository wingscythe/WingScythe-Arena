using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Slider hp_slider;
    public Text health_display;
    public Animator anims;

    // Start is called before the first frame update
    void Start()
    {
        anims.SetInteger("health", (int)hp_slider.value);
    } 

    // Update is called once per frame
    void Update()
    {
        health_display.text = "HP: " + hp_slider.value.ToString() + " / " + hp_slider.maxValue;
        hp_slider.value = (float)anims.GetInteger("health");
    }
}

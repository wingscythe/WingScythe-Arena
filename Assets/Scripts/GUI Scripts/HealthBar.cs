using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider hp_slider;
    public Gradient color_gradient;
    public Image fill;

    public void SetMinHealth(int health)
    {
        hp_slider.minValue = health;
        fill.color = color_gradient.Evaluate(0f);
    }

    public void SetMaxHealth(int health)
    {
        hp_slider.maxValue = health;
        color_gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        hp_slider.value = health;
        fill.color = color_gradient.Evaluate(hp_slider.normalizedValue);
    }

    public void Update()
    {
        fill.color = color_gradient.Evaluate(hp_slider.normalizedValue);
    }
}

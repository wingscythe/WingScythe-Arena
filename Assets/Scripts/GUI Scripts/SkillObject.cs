using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillObject : MonoBehaviour
{
    public KeyCode inputKey;
    public Image skillImage;
    public bool onCooldown = false;
    public float cooldownDuration = 1f;
    private float startTime;
    public float timePassed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        skillImage.fillAmount = cooldownDuration;
    }

    // Update is called once per frame
    void Update()
    {
        adjustCooldown();
    }

    void adjustCooldown() 
    {
        if (Input.GetKey(inputKey) && !onCooldown)
        {
            skillImage.fillAmount = 0f;
            onCooldown = true;
            timePassed = 0f;
        }
        if (onCooldown)
        {
            timePassed += Time.deltaTime;
            skillImage.fillAmount = (float)timePassed / cooldownDuration;
            if (timePassed >= cooldownDuration)
            {
                onCooldown = false;
                timePassed = 0f;
            }
        }
    }
}

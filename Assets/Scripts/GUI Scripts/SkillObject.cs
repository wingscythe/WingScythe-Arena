using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillObject : MonoBehaviour
{
    public KeyCode inputKey;
    public Image skillImage;
    public bool onCooldown = false;
    public float cooldownTime;
    private float startTime;
    private float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        skillImage.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = Time.time - startTime;
        if (Input.GetKey(inputKey) && !onCooldown) {
            onCooldown = true;
        } else if (onCooldown) {
            
        }
    }
}

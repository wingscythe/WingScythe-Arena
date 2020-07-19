using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimeText : MonoBehaviour
{
    public Text timeLeft;
    private float timePassed;
    public SkillObject skill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int timeRemaining = (int) (skill.cooldownDuration - skill.timePassed);
        if (timeRemaining == skill.cooldownDuration) {
            timeLeft.text = "";
        }
        else
        {
            timeLeft.text = timeRemaining.ToString();    
        }
    }
}

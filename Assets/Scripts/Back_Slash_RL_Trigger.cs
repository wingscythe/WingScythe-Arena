using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Slash_RL_Trigger : MonoBehaviour
{
    public Animator anims;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "sword") {
            anims.SetBool("hit_back_slash_RL", true);
        }
    }
}

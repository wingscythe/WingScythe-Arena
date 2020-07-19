using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Front_Slash_RL_Trigger : MonoBehaviour
{
    public Animator anims;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "sword") {
            anims.SetBool("hit_front_slash_RL", true);
            anims.SetInteger("health", anims.GetInteger("health")-2);
        }
    }
}

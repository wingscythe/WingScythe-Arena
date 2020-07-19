using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Front_Slash_LR_Trigger : MonoBehaviour
{
    public Animator anims;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "sword") {
            anims.SetBool("hit_front_slash_LR", true);
        }
    }
}

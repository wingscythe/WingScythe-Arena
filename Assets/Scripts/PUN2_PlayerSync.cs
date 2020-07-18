using UnityEngine;
using Photon.Pun;

public class PUN2_PlayerSync : MonoBehaviourPun, IPunObservable {

    //List of the scripts that should only be active for the local player (ex. PlayerController, MouseLook etc.)
    public MonoBehaviour[] localScripts;
    //List of the GameObjects that should only be active for the local player (ex. Camera, AudioListener etc.)
    public GameObject[] localObjects;
    //Values that will be synced over network
    Vector3 latestVelocity;

    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

        if (photonView.IsMine) {
        } else {
            //Player is Remote, deactivate the scripts and object that should only be enabled for the local player
            for (int i = 0; i < localScripts.Length; i++) {
                localScripts[i].enabled = false;
            }
            for (int i = 0; i < localObjects.Length; i++) {
                localObjects[i].SetActive(false);
            }
        }
    }

    public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            //We own this player: send the others our data
            stream.SendNext(rb.velocity);
        } else {
            //Network player, receive data
            latestVelocity = (Vector3)stream.ReceiveNext();
        }
    }

    // Update is called once per frame
    void Update () {
        if (!photonView.IsMine) {
            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            rb.velocity = Vector3.Lerp(transform.position, latestVelocity, Time.deltaTime * 5);
        }
    }
}
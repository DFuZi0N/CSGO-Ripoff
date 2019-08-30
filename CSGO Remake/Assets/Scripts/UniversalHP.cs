using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UniversalHP : NetworkBehaviour
{
    public float hp;
    public PlayerShoot killer;

    void Start () {
        hp = 100f;
	}

     public void KillPlayer(GameObject _otherPlayer)
    {
        _otherPlayer.GetComponent<PlayerMotor>().enabled = false;
        _otherPlayer.GetComponent<PlayerController>().enabled = false;
        _otherPlayer.GetComponentInChildren<MeshRenderer>().enabled = false;
        _otherPlayer.GetComponent<CapsuleCollider>().enabled = false;
        _otherPlayer.GetComponent<PlayerShoot>().enabled = false;
        _otherPlayer.transform.position = 

    }
}

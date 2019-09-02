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
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject player;
    public Rigidbody rb;
    public float speed;
    public Transform newRot;
    public Vector3 mPrevPos;

	void Start () {
        this.transform.rotation = player.transform.rotation;
        speed = 10f;
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {

     



    }
}

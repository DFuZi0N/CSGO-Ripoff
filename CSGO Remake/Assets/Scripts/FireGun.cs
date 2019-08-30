using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FireGun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public GameObject markPrefab;
    public ContactPoint ColPoint;


    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void OnTriggerEnter(Collider collided)
    {
       

    }




}

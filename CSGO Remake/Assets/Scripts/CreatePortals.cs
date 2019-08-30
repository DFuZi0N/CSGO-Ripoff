using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortals : MonoBehaviour {

    public GameObject portalA;
    public GameObject portalB;
    public bool yes = false;

	void Start () {

        portalA.SetActive(false);
        portalB.SetActive(false);
        
	}
	

	void Update () {
		    
        if(Input.GetMouseButtonDown(0))
        {
            portalA.SetActive(true);
            shootPortal(portalA);

            

        }
        else if(Input.GetMouseButtonDown(1))
        {
            portalB.SetActive(true);
            shootPortal(portalB);
        }

	}

    void shootPortal(GameObject portal)
    {
        Ray origin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hitObj;

        if(Physics.Raycast(origin, out hitObj))
        {

         if(hitObj.collider.tag == "Unportalable")
            {
                // do nothing lmao
            }

         else
            {
                Quaternion findNorm = Quaternion.LookRotation(hitObj.normal);
                portal.transform.position = hitObj.point;
                portal.transform.rotation = findNorm;
                Debug.Log(hitObj.collider.name);
            }


        }
    }
}

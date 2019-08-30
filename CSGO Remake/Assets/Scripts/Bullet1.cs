using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour {

    [SerializeField] float bSpeed = 10.0f;
    Vector3 mPrevPos;
    [SerializeField] ContactPoint ColPoint;
    [SerializeField] GameObject markPrefab;

    void Start () {

        mPrevPos = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        mPrevPos = transform.position;
        transform.Translate(bSpeed * Time.deltaTime, 0.0f, 0.0f);

        RaycastHit[] hits = Physics.RaycastAll(new Ray(mPrevPos, (transform.position - mPrevPos).normalized), (transform.position - mPrevPos).magnitude);

        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].collider.gameObject.name);
        }

        Debug.DrawLine(transform.position, mPrevPos);
    }

    private void OnCollisionEnter(Collision collided)
    {
       
            ColPoint = collided.contacts[0];
            GameObject tempBulletHandler;
            tempBulletHandler = Instantiate(markPrefab, ColPoint.point, Quaternion.LookRotation(ColPoint.normal)) as GameObject;
            tempBulletHandler.transform.Rotate(Vector3.right * 90);
            tempBulletHandler.transform.Translate(Vector3.up * 0.005f);

            Destroy(tempBulletHandler, 3.0f);
            Destroy(this.gameObject);


        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float rotLimit = 85f;

    public bool isRunning = false;
    public bool isGrounded = false;

    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    public float jumpForce = 30f;
    public GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }


    public void rotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
        CheckIsGrounded();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {

            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        
            if (isGrounded) {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false; 
            }

        }

        

    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }

    }

    void CheckIsGrounded()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(player.transform.position, transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity)) {
            
            if(hit.distance <= 2)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

        }
    }

}

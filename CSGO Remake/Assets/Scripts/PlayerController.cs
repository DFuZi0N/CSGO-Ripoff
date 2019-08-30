using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float runSpeed = 7f;
    [SerializeField]
    private float sensitivity = 3f;

    private PlayerMotor motor;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        motor = GetComponent<PlayerMotor>();

    }

    private void Update()
    {

        
     
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;
        Vector3 _runVelocity = (_movHorizontal + _movVertical).normalized * runSpeed;

        if(motor.isRunning)
        {
            motor.move(_runVelocity);

        }
        else if(!motor.isRunning)
        {
            motor.move(_velocity);
        }

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * sensitivity;

        motor.rotate(_rotation);

        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * sensitivity;

        motor.rotateCamera(_cameraRotation);


    }

}

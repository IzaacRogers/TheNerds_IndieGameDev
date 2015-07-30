using UnityEngine;
using System.Collections;

public class FlyCam : MonoBehaviour {

    public GameObject player;
    
    public float mouseSensitivity;

    CharacterController cc;

    public float speed;
    private float rotRange = 90;

    void Start()
    {
        cc = player.GetComponent<CharacterController>();

    }


    float horizantalVel, downVel, verticalVel;
    float xRot, yRot;
    void Update()
    {

        //mouse look
        yRot = Input.GetAxis("Mouse X") * mouseSensitivity;
        //transform.Rotate(0, yRot, 0);\
        transform.localRotation = Quaternion.Euler(0, yRot, 0);

        xRot -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRot = Mathf.Clamp(xRot, -rotRange, rotRange);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        //transform.Rotate(-xRot, 0, 0);


        //movement calc
        verticalVel = Input.GetAxis("Vertical") * speed;
        horizantalVel = Input.GetAxis("Horizontal") * speed;
        if (Input.GetKey(KeyCode.E))
            downVel = speed;
        else if (Input.GetKey(KeyCode.Q))
            downVel = -speed;
        else
            downVel = 0;

        //if (!cc.isGrounded) downVel += Physics.gravity.y * Time.deltaTime;

        //movement implimentation
        Vector3 velocity = new Vector3(horizantalVel, downVel, verticalVel);
        velocity = transform.rotation * velocity;
        cc.Move(velocity * Time.deltaTime);


    }
}

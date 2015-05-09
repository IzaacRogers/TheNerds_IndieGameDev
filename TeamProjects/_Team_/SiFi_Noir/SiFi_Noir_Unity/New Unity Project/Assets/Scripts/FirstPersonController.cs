using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

    public GameObject player;
    public GameObject cam;
    public float baseSpeed;
    public float speedMult;
    public float mouseSensitivity;

    CharacterController cc;

    private float speed;
    private float rotRange = 90;

	void Start () {
        cc = player.GetComponent<CharacterController>();
	    
	}


    float horizantalVel, downVel, verticalVel;
    float xRot, yRot;
	void Update () {

        //mouse look
        yRot = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, yRot, 0);

        xRot -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRot = Mathf.Clamp(xRot, -rotRange, rotRange);
        cam.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
   

        //speed calc
        speed = baseSpeed * speedMult;

        //movement calc
        verticalVel = Input.GetAxis("Vertical") * speed;
        horizantalVel = Input.GetAxis("Horizontal") * speed;
        if (!cc.isGrounded) downVel += Physics.gravity.y * Time.deltaTime;

        //movement implimentation
        Vector3 velocity = new Vector3(horizantalVel, downVel, verticalVel);
        velocity = transform.rotation * velocity;
        cc.Move(velocity * Time.deltaTime);

	
	}
}

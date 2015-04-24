using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    //<PlayerControles>
    public GameObject Player;
    public CharacterController cc;
    Vector3 movement;

    public float speed;
    public float forward;
    public float walkSpeed = 2;
    public float jump = 4;
    public float dodge = 10;

    public float mouseSense = 5;

    public float yVel;

    float xRot;
    float yPor;
    float rotRange = 60f;
    //</PlayerControles>

    int cameraSelect = 0;
    List<GameObject> Cameras;
    
    public GameObject Target;


	// Use this for initialization
	void Start () {
        cc = Player.GetComponent<CharacterController>();
        Target = GameObject.FindGameObjectWithTag("Target");
        Cameras = new List<GameObject>();
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Camera").Length; i++) 
        {
            Cameras.Add(GameObject.FindGameObjectsWithTag("Camera")[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {

        speed = Input.GetAxis("Horizontal");
        forward = Input.GetAxis("Vertical");

        //jump
        if (cc.isGrounded) {
            yVel = 0f;
            if (Input.GetKey(KeyCode.Space))
                yVel = jump;
        }else{
            yVel += Physics.gravity.y * Time.deltaTime;
        }


        movement = new Vector3(speed, yVel, forward);
        movement = transform.rotation * movement;
        Vector3 lookAt = new Vector3(Target.transform.position.x, Target.transform.position.y + 1, Target.transform.position.z);
        Player.transform.LookAt(lookAt);
        if (Input.GetKey(KeyCode.None))
        {
            movement = new Vector3(0, 0, 0);
        }

        cc.Move(movement * Time.deltaTime);

	}
}

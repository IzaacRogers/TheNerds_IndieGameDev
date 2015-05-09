using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {

    public GameObject player;
    CharacterController cc;

    public GameObject camera;
    Camera cam;
    ThirdPersonCameraController camController;

    public float baseSpeed;
    public float speedMult;
    public float mouseSensitivity;

    private float speed;

	// Use this for initialization
	void Start () {
        cc = player.GetComponent<CharacterController>();
        camController = GetComponent<ThirdPersonCameraController>();
        cam = camera.GetComponent<Camera>();

	}

    float horizontalVel, downVel, verticalVel;
    void Update () {

        speed = baseSpeed*speedMult;

        verticalVel = Input.GetAxis("Vertical") * speed;
        horizontalVel = Input.GetAxis("Horizontal") * speed;
        if (!cc.isGrounded) downVel += Physics.gravity.y * Time.deltaTime;

        Vector3 velocity = new Vector3(horizontalVel, downVel, verticalVel);
        velocity = transform.rotation * velocity;
        cc.Move(velocity * Time.deltaTime);

	}
}

using UnityEngine;
using System.Collections;

public class ThirdPersonCameraController : MonoBehaviour {

    public GameObject player;
    public GameObject target;
    public float mouseSensitivity;

    public ThirdPersonCameraController() {/*constructor*/}

    private float rotRange = 70;

	// Use this for initialization
	void Start () {
	
	}

    private float xRot, yRot;
	void Update () {
        yRot = Input.GetAxis("Mouse X") * mouseSensitivity;
        player.transform.Rotate(0, yRot, 0);

        xRot -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRot = Mathf.Clamp(xRot, -rotRange, rotRange);
        target.transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        

	
	}
}

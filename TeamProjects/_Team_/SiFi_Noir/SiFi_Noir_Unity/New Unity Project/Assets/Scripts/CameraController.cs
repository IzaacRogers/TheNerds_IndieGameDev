using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject fpsCamPos;
    public GameObject tpsCamPos;
    public GameObject player;
    FirstPersonController fpsController;
    ThirdPersonController tpsController;
    ThirdPersonCameraController tpsCamController;

    public GameObject camera;
    Camera cam;

    public bool isFirstPerson = false;

	// Use this for initialization
	void Start () {
        cam = camera.GetComponent<Camera>();
        fpsController = player.GetComponent<FirstPersonController>();
        tpsController = player.GetComponent<ThirdPersonController>();
        tpsCamController = camera.GetComponent<ThirdPersonCameraController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isFirstPerson) {
            camera.transform.position = fpsCamPos.transform.position;
            fpsController.enabled = true;
            tpsController.enabled = false;
            tpsCamController.enabled = false;
        }
        else if (!isFirstPerson) {
            camera.transform.position = tpsCamPos.transform.position;
            fpsController.enabled = false;
            tpsController.enabled = true;
            tpsCamController.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.V)) 
        {
            if (isFirstPerson)
                setPOV(3);
            else if (!isFirstPerson)
                setPOV(1);
        }
	
	}

    public void setPOV(int pov) {
        if (pov == 1)
            isFirstPerson = true;
        else if (pov == 3)
            isFirstPerson = false;
    }
}

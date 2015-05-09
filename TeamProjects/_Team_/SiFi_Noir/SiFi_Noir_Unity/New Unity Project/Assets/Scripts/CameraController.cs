using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject fpsCamPos;
    public GameObject fpsGraphics;
    public GameObject tpsCamPos;
    public GameObject tpsGraphics;
    public GameObject player;
    FirstPersonController fpsController;
    ThirdPersonController tpsController;
    ThirdPersonCameraController tpsCamController;
    Animator tpsAnim;

    public GameObject camera;
    Camera cam;

    public bool isFirstPerson = false;

	// Use this for initialization
	void Start () {
        cam = camera.GetComponent<Camera>();
        fpsController = player.GetComponent<FirstPersonController>();
        tpsController = player.GetComponent<ThirdPersonController>();
        tpsCamController = camera.GetComponent<ThirdPersonCameraController>();
        tpsAnim = player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.V))
            if (isFirstPerson) {
                camera.transform.position = fpsCamPos.transform.position;
                fpsGraphics.SetActive(true);
                fpsController.enabled = true;
                tpsGraphics.SetActive(false);
                tpsController.enabled = false;
                tpsCamController.enabled = false;
                tpsAnim.enabled = false;
            }
            else if (!isFirstPerson) {
                camera.transform.position = tpsCamPos.transform.position;
                fpsGraphics.SetActive(false);
                fpsController.enabled = false;
                tpsGraphics.SetActive(true);
                tpsController.enabled = true;
                tpsCamController.enabled = true;
                tpsAnim.enabled = true;
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

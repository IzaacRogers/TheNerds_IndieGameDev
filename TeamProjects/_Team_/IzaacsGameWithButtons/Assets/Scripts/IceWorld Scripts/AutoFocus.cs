using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class AutoFocus : MonoBehaviour {

    DepthOfField dof;
    public GameObject cam;

    GameObject trans;

    private float delay = 1;
    private float cooldown = 0;
    private float offs;

	// Use this for initialization
	void Start () {
        dof = this.GetComponent<DepthOfField>();
        trans = new GameObject("focusPoint");
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (cooldown < delay){
            cooldown += Time.deltaTime;
        } else {
            offs = Random.Range(-5, 5);
            cooldown = 0;
            delay = Random.Range(0, 3);
        }

        if (Physics.Raycast(ray, out hit, 50))
        {
            trans.transform.position = hit.point;
            trans.transform.position = new Vector3(trans.transform.position.x + offs, trans.transform.position.y + offs, trans.transform.position.z + offs);
            dof.focalTransform = trans.transform;
        }
	}
}

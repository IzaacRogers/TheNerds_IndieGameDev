using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LazerBeam : MonoBehaviour {
    public Vector3 startPoint;
    public Vector3 endPoint;

    LineRenderer beam;

	// Use this for initialization
	void Start () {
        beam = this.GetComponent<LineRenderer>();

        beam.SetPosition(0, new Vector3(startPoint.x + this.transform.position.x, startPoint.y + this.transform.position.y, startPoint.z + this.transform.position.z));
        beam.SetPosition(1, new Vector3(endPoint.x + this.transform.position.x, endPoint.y + this.transform.position.y, endPoint.z + this.transform.position.z));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

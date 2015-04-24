using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {

    GameObject target;
    Rigidbody2D ridgid;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        ridgid = this.GetComponentInChildren<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {


        ridgid.velocity = new Vector2(target.transform.position.x, target.transform.position.y);
	
	}
}

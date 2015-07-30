using UnityEngine;
using System.Collections;

public class DebugTest : MonoBehaviour {
    GraphicDebug debug = new GraphicDebug();

	// Use this for initialization
	void Start () {
        debug.drawPoint(new Vector3(1, 1, 1));
        debug.drawPoint(new Vector3(-1, -1, -1));
        debug.drawDirection(new Vector3(1,1,1), new Vector3(-1,-1,-1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

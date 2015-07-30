using UnityEngine;
using System.Collections;

public class ProceduralMap : MonoBehaviour {

    public string seed;
    public int drawDistance;
    public float[,] map;
    public float scale;

	// Use this for initialization
	void Start () {
        //noiseHeight = drawDistance;
        //noiseWidth = drawDistance;

        GenerateMap();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            GenerateMap();
	}

    void GenerateMap() 
    {
        map = new float[drawDistance, drawDistance];
        ProceduralMesh meshGen = GetComponent<ProceduralMesh>();
        meshGen.GenerateMesh(map, 1);
        
    }
}

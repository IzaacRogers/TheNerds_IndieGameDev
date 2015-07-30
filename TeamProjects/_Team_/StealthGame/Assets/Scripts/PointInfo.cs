using UnityEngine;
using UnityEditor;
using System.Collections;

public class PointInfo : MonoBehaviour {

    public Material defaultMat;
    public Material selectedMat;

    private Collider collider;
    public bool selected = false;
    private GameObject me;
    private MeshRenderer renderer;
	// Use this for initialization
	void Start () {
        defaultMat = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/Debug_Default.mat", typeof(Material));
        selectedMat = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/Debug_Selected.mat", typeof(Material));

        collider = this.GetComponent<Collider>();
        collider.isTrigger = true;
        me = this.gameObject;
        renderer = me.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (selected)
            renderer.material = selectedMat;
        else
            renderer.material = defaultMat;
	}

    public void OnMouseOver() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            selected = !selected;
            Debug.Log("Mouse Down");
        }
    }
}

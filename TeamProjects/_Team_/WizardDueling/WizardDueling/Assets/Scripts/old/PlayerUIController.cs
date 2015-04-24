using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerUIController : MonoBehaviour {

    public GameObject GUI;

    private bool casting;
    private int textIndex;

    
    List<Text> text;
    private Canvas canvas;

    public PlayerUIController() {/*constructor*/}

	// Use this for initialization
	void Start () {
        canvas = GUI.GetComponent<Canvas>();

        //text = GUI.GetComponentInChildren<Text>();
        text = new List<Text>();

        textIndex = GUI.GetComponentsInChildren<Text>().Length;
        for(int i=0; i<textIndex;i++){
            text.Add(GUI.GetComponentsInChildren<Text>()[i]);
        }

        CreatePie();


	}
	
	// Update is called once per frame
	void Update () {

        

        if (Input.GetKey(KeyCode.LeftControl) == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0.25f;
            casting = true;
            //shows pie chart
            for (int i = 0; i < textIndex; i++) {
                text.ToArray()[i].gameObject.SetActive(true);
            }
        }
        else 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            casting = false;
            //hides pie chart
            for (int i = 0; i < textIndex; i++)
            {
                text.ToArray()[i].gameObject.SetActive(false);
            }
        }
	
	}


    public bool isCasting() {
        return casting;
    }

    public void setCasting(bool b) {
        casting = b;
    }


    public void CreatePie() 
    {
        int n = textIndex;
        int radius = 250;
        float angle;
        float xcoord, zcoord;

        float xoffs = canvas.transform.position.x, 
              yoffs = canvas.transform.position.y;

        Quaternion rotation = Quaternion.identity;

        for (int i = 0; i < n; i++)
        {

            angle = ((i) * Mathf.PI * 2/n);
            xcoord = radius * Mathf.Cos(angle);
            zcoord = radius * Mathf.Sin(angle);
            rotation.eulerAngles = new Vector3(0, angle, 0);
            //cube.transform.position = new Vector3(xcoord, 2, zcoord);
            //cube.transform.rotation = rotation;

            text.ToArray()[i].transform.position = new Vector3(xcoord + xoffs, zcoord + yoffs, 0);

        }
    }

}

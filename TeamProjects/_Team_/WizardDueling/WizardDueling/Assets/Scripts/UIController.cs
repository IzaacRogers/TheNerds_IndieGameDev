using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

    //<GUI>
    //this is the canvas the spells are held in
    //</GUI>
    public GameObject GUI;
    public Material mat;

    private Canvas canvas;
    private List<Text> text;
    private int textIndex;
    private bool casting;

    public GameObject Pie;
    private List<MeshRenderer> rend;
    private int rendIndex;


    PauseGame pauseGame;

    GameObject Player;
    public GameObject slide;
    CastSpell castSpell;
    Slider focusSlider;


    //Constructor
    public UIController() { }
    //<setters_getters>
    public bool isCasting() { return casting; }
    public void setCasting(bool b) { casting = b; } 
    //</setters_getters>

	// Use this for initialization
	void Start () {
        pauseGame = ScriptableObject.CreateInstance<PauseGame>();
        canvas = GUI.GetComponent<Canvas>();
        text = new List<Text>();

        textIndex = GUI.GetComponentsInChildren<Text>().Length;
        for (int i = 0; i < textIndex; i++)
        {
            text.Add(GUI.GetComponentsInChildren<Text>()[i]);
        }

        rend = new List<MeshRenderer>();
        rendIndex = Pie.GetComponentsInChildren<MeshRenderer>().Length;
        for (int i = 0; i < rendIndex; i++) 
        {
            rend.Add(Pie.GetComponentsInChildren<MeshRenderer>()[i]);
        }

        CreatePie();

        Player = GameObject.FindWithTag("Player");
        castSpell = Player.GetComponent<CastSpell>();
        focusSlider = slide.GetComponent<Slider>();

	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyUp(KeyCode.P)) 
        {
            pauseGame.Pause();
        }

        if (Input.GetKey(KeyCode.LeftControl) == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0.25f;
            casting = true;
            //shows pie chart
            for (int i = 0; i < textIndex; i++)
            {
                text.ToArray()[i].gameObject.SetActive(true);
                rend.ToArray()[i].gameObject.SetActive(true);
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
                rend.ToArray()[i].gameObject.SetActive(false);

            }
         }

        focusSlider.value = castSpell.focus;
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

            angle = ((i) * Mathf.PI * 2 / n);
            xcoord = radius * Mathf.Cos(angle);
            zcoord = radius * Mathf.Sin(angle);
            rotation.eulerAngles = new Vector3(0, angle, 0);

            text.ToArray()[i].transform.position = new Vector3(xcoord + xoffs, zcoord + yoffs, 0);
        }
    }
}

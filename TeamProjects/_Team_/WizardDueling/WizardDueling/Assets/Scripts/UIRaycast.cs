using UnityEngine;
using System.Collections;

public class UIRaycast : MonoBehaviour {

    public Camera caster;
    GameObject player;
    CastSpell castSpell;

    GameObject select;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        castSpell = player.GetComponent<CastSpell>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftControl)) 
        {
            Ray ray = caster.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5)) 
            {
                if (hit.collider == true) 
                {
                    select = hit.collider.gameObject;
                    castSpell.setCast(select.GetComponent<SetSpellCast>().getCast());
                }
            }
        }
	
	}
}

using UnityEngine;
using System.Collections;

public class SpriteTypeManager : MonoBehaviour {

    public int Type ;

    public GameObject[] components;

	// Use this for initialization
	void Awake () {
        components[0].SetActive(false);
        components[1].SetActive(false);
        components[2].SetActive(false);
        components[3].SetActive(false);
        components[4].SetActive(false);
        components[5].SetActive(false);

        if (Type == 1) {
            components[0].SetActive(true);
        }

        if (Type == 2) {
            components[2].SetActive(true);
            components[3].SetActive(true);
            components[4].SetActive(true);
            components[5].SetActive(true);
        }
        if (Type == 3) {
            components[1].SetActive(true);
        }
	}
}

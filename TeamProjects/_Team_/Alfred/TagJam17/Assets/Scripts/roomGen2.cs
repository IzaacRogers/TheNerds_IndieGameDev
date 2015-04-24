using UnityEngine;
using System.Collections;

public class roomGen2 : MonoBehaviour {
    public GameObject[] rooms;

    public GameObject parent;
    GameObject currentRoom;
    GameObject player;

    void OnTriggerEnter2D(Collider2D c) 
    {
        int i = pickRoom();

        Instantiate(rooms[i], rooms[i].transform.position, rooms[i].transform.rotation);

        player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = new Vector3(0, 0, 0);

        /*
         * do something to move the character
         * to the correct position
         */

        currentRoom = GameObject.FindGameObjectsWithTag("Room")[0];
        //Destroy(currentRoom);
        currentRoom.SetActive(false);
        
    }

    int pickRoom() 
    {
        int r = Random.Range(0, rooms.Length - 1);
        return r;
    }
}

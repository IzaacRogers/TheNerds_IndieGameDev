using UnityEngine;
using System.Collections;

public class RoomGen : MonoBehaviour {

    public GameObject[] rooms;
    public GameObject parent;
    Collider2D col;
    RoomTools RT;

    int i = 0;

    public void Start() 
    {
        i = Random.Range(0, rooms.Length-1);
        RT = rooms[i].GetComponent<RoomTools>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Vector3 roomPosition = new Vector3(rooms[i].transform.position.x, parent.transform.position.y /*+ ((float)(RT.getLength()))*/, parent.transform.position.z);
        Debug.Log(parent.transform.position.x);
        //roomPosition = parent.transform.rotation * roomPosition;

        Instantiate(rooms[i], roomPosition, Quaternion.identity);
        col = this.GetComponent<Collider2D>();
        col.enabled = false;
        
    }

    void getRoomPlacement() 
    {   
        
    }
}

using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    public GameObject trans;
    public GameObject target;

    public GameObject marker;

    Vector3 targetPosition;
    float timer = 1;

    // basic movement functions
    void forward(){
        trans.transform.position = new Vector3(trans.transform.position.x, trans.transform.position.y, trans.transform.position.z + 1);
    }
    void backward(){
        trans.transform.position = new Vector3(trans.transform.position.x, trans.transform.position.y, trans.transform.position.z - 1);
    }
    void right(){
        trans.transform.position = new Vector3(trans.transform.position.x + 1, trans.transform.position.y, trans.transform.position.z);
    }
    void left(){
        trans.transform.position = new Vector3(trans.transform.position.x - 1, trans.transform.position.y, trans.transform.position.z);
    }

    void Start() {

    }

    void Update() {
        if (Vector3.Distance(trans.transform.position, targetPosition)<=1)
        {
            targetPosition = new Vector3(Random.Range(trans.transform.position.x - 5, trans.transform.position.x + 5), trans.transform.position.y, Random.Range(trans.transform.position.z - 5, trans.transform.position.z + 5));
            int tX = (int)targetPosition.x; int tY = (int)targetPosition.y; int tZ = (int)targetPosition.z;
            targetPosition.x = tX; targetPosition.y = tY; targetPosition.z = tZ;
            GameObject mark = (GameObject)Instantiate(marker, targetPosition, Quaternion.identity);
        }

        if (timer < 0)
        {
            timer = .01f;
            if (Vector3.Distance(trans.transform.position, targetPosition) > 1)
                if (targetPosition.x >= trans.transform.position.x+1)
                    right();
                else if (targetPosition.x <= trans.transform.position.x-1)
                    left();
                else if (targetPosition.z >= trans.transform.position.z+1)
                    forward();
                else if (targetPosition.z <= trans.transform.position.z-1)
                    backward();
        }
        else 
        {
            timer -= Time.deltaTime;
        }
    }

}

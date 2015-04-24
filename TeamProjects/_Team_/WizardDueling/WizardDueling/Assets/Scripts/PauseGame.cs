using UnityEngine;
using System.Collections;

public class PauseGame : ScriptableObject {

    private bool paused;

    //constructor
    public PauseGame() {
        Debug.Log("_INIT_");
    }

    public bool isPaused() 
    {
        return paused;
    }

    public void Pause()
    {
        if (paused == false)
        {
            Debug.Log("paused");
            //paused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

        if (paused == true)
        {
            Debug.Log("Unpaused");
            //paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }

        paused = !paused;
        Debug.Log("Paused is: " + paused);
    }
}

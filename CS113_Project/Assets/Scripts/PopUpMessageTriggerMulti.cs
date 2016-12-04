using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMessageTriggerMulti : MonoBehaviour {

    public bool triggered = false;
    //GUIStyle style = new GUIStyle();
    //public string message;

    public Texture2D[] texture2;
    bool paused = false;
    int already_shown = 0;
    int i = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && GameControl.control.all_set == false && already_shown == 0)
        {
            print("hit");
            triggered = true;
            paused = true;
            Time.timeScale = 0;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            triggered = false;
            already_shown += 1;
            i -= 1;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && triggered == true)
        {
            i += 1;
        }
    }

    void OnGUI()
    {
        if (triggered && already_shown == 0 && paused == true)
        {
            //style.fontSize = 20;
            //GUI.Label(new Rect(Screen.width / 2, Screen.height * 0.75f , 150, 50), message, style);
            if (i < texture2.Length)
            {
                GUI.Label(new Rect(0, Screen.height * 0.75f, texture2[i].width, texture2[i].height), texture2[i]);
            }
            if (paused == true && Input.GetKeyUp("space"))
            {
                if (i >= texture2.Length)
                {
                    paused = false;
                    Time.timeScale = 1;
                }
            }
        }
    }
}

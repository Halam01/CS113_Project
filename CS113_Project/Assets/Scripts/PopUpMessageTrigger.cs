using UnityEngine;
using System.Collections;

public class PopUpMessageTrigger : MonoBehaviour {

    public bool triggered = false;
    //GUIStyle style = new GUIStyle();
    //public string message;

    public Texture2D texture2;
    bool paused = false;
    int already_shown = 0;

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
        }
    }

    void OnGUI()
    {
        if (triggered && already_shown == 0 && paused == true)
        {
            //style.fontSize = 20;
            //GUI.Label(new Rect(Screen.width / 2, Screen.height * 0.75f , 150, 50), message, style);
            //GUI.Label(new Rect(0, Screen.height * 0.75f, Screen.width, Screen.height * 0.25f), texture2);
            GUI.DrawTexture(new Rect(0, Screen.height * 0.75f, Screen.width, Screen.height * 0.25f), texture2);
            if (paused == true && Input.GetKeyDown("space"))
            {
                paused = false;
                Time.timeScale = 1;
            }
        }
    }
}

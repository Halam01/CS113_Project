using UnityEngine;
using System.Collections;

public class PopUpMessage : MonoBehaviour {

    public bool touched = false;
    GUIStyle style = new GUIStyle();
    public string message;

	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && GameControl.control.all_set == false)
        {
            print("hit");
            touched = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            touched = false;
        }
    }

    void OnGUI()
    {
        if (touched)
        {
            style.fontSize = 20;
            GUI.Label(new Rect(Screen.width / 2, Screen.height * 0.75f , 150, 50), message, style);
        }
    }
}

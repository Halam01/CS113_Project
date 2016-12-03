using UnityEngine;
using System.Collections;

public class PopUpMessage : MonoBehaviour {

    public bool touched = false;
    GUIStyle style = new GUIStyle();
    //public string message;

    public Texture2D[] texture;
    int i = -1;

	void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player" && GameControl.control.all_set == false && Input.GetKeyUp("space") && col.GetComponent<Controller>().holding == false)
        {
            print("hit");
            touched = true;
            i += 1;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            touched = false;
            i = -1;
        }
    }


    void OnGUI()
    {
        if (touched)
        {
            print(i);
            style.fontSize = 20;
            //GUI.Label(new Rect(Screen.width / 2, Screen.height * 0.75f , 150, 50), message, style);
            if (i < texture.Length && i >= 0)
            {
                GUI.Label(new Rect(0, Screen.height * 0.75f, Screen.width, texture[i].height), texture[i]);
            }
        }
    }
}

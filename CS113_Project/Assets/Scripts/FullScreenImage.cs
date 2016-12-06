using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenImage : MonoBehaviour {

    public Texture2D img;
    GUIStyle gstyle = new GUIStyle();

    void OnGUI()
    {
        gstyle.fixedWidth = 0;
        gstyle.stretchWidth = true;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), img, gstyle);
    }
}

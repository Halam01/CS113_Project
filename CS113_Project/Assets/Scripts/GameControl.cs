using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public float health;
    public float experience;

	// Use this for initialization
	void Awake () {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
        
	}
	
	void OnGUI()
    {
        //temp variables, just to see how saving data works between scenes, can access these variables via control.method/variable
        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health);
        GUI.Label(new Rect(10, 40, 100, 30), "Experience: " + experience);
    }
}

using UnityEngine;
using System.Collections;

public class DevMode : MonoBehaviour {

    private GameObject[] myDoors;
	// Use this for initialization
	void Start () {
        myDoors = GameObject.FindGameObjectsWithTag("Door");
        if (myDoors.Length == 0)
            print("couldn't find doors");
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            foreach (GameObject door in myDoors)
            {
                if (door.GetComponent<BoxCollider>().enabled)
                    door.GetComponent<BoxCollider>().enabled = false;
                else
                    door.GetComponent<BoxCollider>().enabled = true;
            }

        }
    }
}

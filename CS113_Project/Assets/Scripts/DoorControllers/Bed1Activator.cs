using UnityEngine;
using System.Collections;

public class Bed1Activator : MonoBehaviour {

    private Component BR1C;
    void Start()
    {
        BR1C = GameObject.Find("Bed1Door").GetComponent("Bed1Controller"); //get a reference to the script that opens the door
        if (BR1C != null)
            print("Found BR1C.cs");
        else
            print("Could not find BR1C.cs");
    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Player") //if the Player exited the box
        {
            print("boutta close BR1 door");
            if (BR1C != null)
                BR1C.SendMessage("setActive"); //close the door
            else
                print("Bedroom1 door disabled");
        }
        //if (Col.gameObject.transform.position.x > transform.position.x) //close door forever if player is on right side
        //    BR1C = null;
    }

    void OnTriggerEnter(Collider Col)
    {
        print("boutta open BR1 door");
        if (Col.gameObject.tag == "Player" && Col.gameObject.transform.position.x < transform.position.x) //only open if player enters from right side.
        {
            if (BR1C != null) //gotta make sure that the BRExitScript isn't null, otherwise ERROR
                BR1C.SendMessage("setActive");
            else
                print("Bedroom1 door disabled");
        }
    }
}

using UnityEngine;
using System.Collections;

public class BathroomOpenClose : MonoBehaviour
{
    private Component BRExitScript;
    void Start()
    {
        BRExitScript = GameObject.Find("BathroomExit").GetComponent("BathroomExit"); //get a reference to the script that opens the door
        if (BRExitScript != null)
            print("Found BRExit.cs");
        else
            print("Could not find BRE.cs");
    }
    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Player") //if the Player exited the box
        {
            print("boutta close BR door");
            if (BRExitScript != null)
                BRExitScript.SendMessage("setActive"); //close the door
            else
                print("Bathroom door disabled");
        }
        if (Col.gameObject.transform.position.z > transform.position.z) //close door forever if player is on left side
            BRExitScript = null;
    }

    void OnTriggerEnter(Collider Col)
    {
        print("boutta open BR door");
        if (Col.gameObject.tag == "Player")
        {
            if (BRExitScript != null) //gotta make sure that the BRExitScript isn't null, otherwise ERROR
                BRExitScript.SendMessage("setActive");
            else
                print("Bathroom door disabled");
        }
    }
}
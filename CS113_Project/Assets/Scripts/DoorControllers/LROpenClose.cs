using UnityEngine;
using System.Collections;

public class LROpenClose : MonoBehaviour
{
    private Component LRExitScript;
    void Start()
    {
        LRExitScript = GameObject.Find("LivingRoomExit").GetComponent("LRExit"); //get a reference to the script that opens the door
        if (LRExitScript != null)
            print("Found LRExit.cs");
        else
            print("Could not find LRE.cs");
    }
    void OnTriggerExit(Collider Col)
    {
        print("boutta close LR door");
        if (Col.gameObject.tag == "Player") //if the Player exited the box
        {
            if (LRExitScript != null)
                LRExitScript.SendMessage("setActive"); //close the door
            else
                print("LR door disabled");
        }
        if(Col.gameObject.transform.position.x < transform.position.x) //close door forever if player is on left side
            LRExitScript = null;
    }

    void OnTriggerEnter(Collider Col)
    {
        print("boutta open LR door");
        if (Col.gameObject.tag == "Player")
        {
            if (LRExitScript != null) //gotta make sure that the LRExitScript isn't null, otherwise ERROR
                LRExitScript.SendMessage("setActive");
            else
                print("LR door disabled");
        }
    }
}
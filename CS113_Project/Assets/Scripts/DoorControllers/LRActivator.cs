using UnityEngine;
using System.Collections;

public class LRActivator : MonoBehaviour
{
    private Component LRC;
    void Start()
    {
        LRC = GameObject.Find("LivingRoomDoor").GetComponent("LRController"); //get a reference to the script that opens the door
        if (LRC != null)
            print("Found LRC.cs");
        else
            print("Could not find LRC.cs");
    }
    void OnTriggerExit(Collider Col)
    {
        print("boutta close LR door");
        if (Col.gameObject.tag == "Player") //if the Player exited the box
        {
            if (LRC != null && Col.gameObject.transform.position.x < transform.position.x) //close door forever if player is on left side
            {
                LRC.SendMessage("close_Door"); //close the door
                LRC = null;
            }
            else
                print("LR door disabled, or player not on left side");
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        print("boutta open LR door");
        if (Col.gameObject.tag == "Ghost")
        {
            print("Ghost hit the door activator!");
            if (LRC != null) //gotta make sure that the LRC isn't null, otherwise ERROR
                LRC.SendMessage("open_Door");
            else
                print("LR door disabled");
        }
    }
}
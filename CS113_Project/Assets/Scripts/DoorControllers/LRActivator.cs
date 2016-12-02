using UnityEngine;
using System.Collections;

public class LRActivator : MonoBehaviour
{
    private Component LRC;
    void Start()
    {
        LRC = GameObject.Find("LivingRoomDoor").GetComponent("LRController"); //get a reference to the script that opens the door
        if (LRC == null)
            print("Could not find LRC.cs");
    }
    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Player" && Col.gameObject.transform.position.x < transform.position.x) //if the Player exited the box
        {
            if (LRC != null)
            {
                LRC.SendMessage("close_Door"); //close the door
                LRC = null;
            }
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Ghost"))
        {
            if (LRC != null) //gotta make sure that the LRC isn't null, otherwise ERROR
                LRC.SendMessage("open_Door");
        }
    }
}
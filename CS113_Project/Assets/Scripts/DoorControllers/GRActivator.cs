using UnityEngine;
using System.Collections;

public class GRActivator : MonoBehaviour
{

    private Component GRC;

    void Start()
    {
        GRC = GameObject.Find("GreatRoomDoor").GetComponent("GRController"); //get a reference to the script that opens the door
        if (GRC != null)
            print("Found GRC.cs");
        else
            print("Could not find GRC.cs");
    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.CompareTag("Player") && Col.gameObject.transform.position.x > transform.position.x)
        {
            print("boutta open GR door");
            if (GRC != null)
                GRC.SendMessage("close_Door");
            else
                print("GR door disabled");
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        if ((Col.gameObject.CompareTag("Player") && Col.gameObject.transform.position.x < transform.position.x) ||
            (Col.gameObject.CompareTag("LRGhost")))
        {
            print("boutta open GR2 door");
            if (GRC != null)
                GRC.SendMessage("open_Door");
            else
                print("GR door disabled");
        }
    }
}
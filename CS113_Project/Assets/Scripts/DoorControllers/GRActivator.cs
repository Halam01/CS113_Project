using UnityEngine;
using System.Collections;

public class GRActivator : MonoBehaviour
{

    private Component GRC;

    void Start()
    {
        GRC = GameObject.Find("GreatRoomDoor").GetComponent("GRController"); //get a reference to the script that opens the door
        if (GRC == null)
            print("Could not find GRC.cs");
    }

    void OnTriggerExit(Collider Col)
    {
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Ghost"))
        {
            if (GRC != null)
            {
                GRC.SendMessage("open_Door");
                Col.gameObject.SetActive(false);
            }
        }
    }
}
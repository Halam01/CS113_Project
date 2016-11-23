﻿using UnityEngine;
using System.Collections;

public class BathroomActivator : MonoBehaviour
{
    private Component BRC;
    void Start()
    {
        BRC = GameObject.Find("BathroomDoor").GetComponent("BathroomController"); //get a reference to the script that opens the door
        if (BRC != null)
            print("Found BRC.cs");
        else
            print("Could not find BRC.cs");
    }
    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Player" && Col.gameObject.transform.position.z > transform.position.z) //if the Player exited the box
        {
            print("boutta close BR door");
            if (BRC != null)
            {
                BRC.SendMessage("close_Door"); //close the door
                BRC = null;
            }
            else
                print("Bathroom door disabled");
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Ghost")
        {
            print("boutta open BR door");
            if (BRC != null) //gotta make sure that the BRExitScript isn't null, otherwise ERROR
                BRC.SendMessage("open_Door");
            else
                print("Bathroom door disabled");
        }
    }
}
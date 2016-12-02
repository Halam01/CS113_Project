using UnityEngine;
using System.Collections;

public class Bed2Activator : MonoBehaviour
{

    private Component BR2C;

    void Start()
    {
        BR2C = GameObject.Find("Bed2Door").GetComponent("Bed2Controller"); //get a reference to the script that opens the door
        if (BR2C == null)
            print("Could not find BR2C.cs");
    }

    void OnTriggerExit(Collider Col)
    {
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Player")) //only open if player enters from left side.
        {
            if (BR2C != null) //gotta make sure that the BRExitScript isn't null, otherwise ERROR
                BR2C.SendMessage("open_Door");
        }
    }
}

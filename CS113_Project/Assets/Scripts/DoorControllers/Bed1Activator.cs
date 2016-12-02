using UnityEngine;
using System.Collections;

public class Bed1Activator : MonoBehaviour {

    private Component BR1C;
    private GameObject player;
    
    void Start()
    {
        BR1C = GameObject.Find("Bed1Door").GetComponent("Bed1Controller"); //get a reference to the script that opens the door
        player = GameObject.Find("Player");
        if (BR1C != null)
            print("Found BR1C.cs");
        else
            print("Could not find BR1C.cs");
    }

    void OnTriggerExit(Collider Col)
    {
        //if (Col.gameObject.tag == "Player") //if the Player exited the box
        //{
        //    print("boutta close BR1 door");
        //    if (BR1C != null)
        //        BR1C.SendMessage("close_Door"); //close the door
        //    else
        //        print("Bedroom1 door disabled");
        //}
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Pick Up") && Col.gameObject.name == "BedKey") //only open if player enters from left side.
        {
            print("boutta open BR1 door");
            if (player != null)
                player.SendMessage("drop");
            if (BR1C != null) //gotta make sure that the BRExitScript isn't null, otherwise ERROR
                BR1C.SendMessage("open_Door");
            else
                print("Bedroom1 door disabled");
            Col.gameObject.SetActive(false);
            Col.enabled = false;
        }
    }
}

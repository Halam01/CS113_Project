using UnityEngine;
using System.Collections;

public class Bed1Activator : MonoBehaviour {

    private Component BR1C;
    private GameObject player;
    
    void Start()
    {
        BR1C = GameObject.Find("Bed1Door").GetComponent("Bed1Controller"); //get a reference to the script that opens the door
        player = GameObject.Find("Player");
        if (BR1C == null)
            print("Couldn't find BR1C.cs");
    }

    void OnTriggerExit(Collider Col)
    {
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Pick Up") && Col.gameObject.name == "BedKey") //only open if player enters from left side.
        {
            if (player != null)
                player.SendMessage("drop");
            if (BR1C != null) //gotta make sure that the BRExitScript isn't null, otherwise ERROR
                BR1C.SendMessage("open_Door");
            Col.gameObject.SetActive(false);
            Col.enabled = false;
        }
    }
}

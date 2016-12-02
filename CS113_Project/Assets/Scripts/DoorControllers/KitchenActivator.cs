using UnityEngine;
using System.Collections;

public class KitchenActivator : MonoBehaviour
{

    private Component KC;

    void Start()
    {
        KC = GameObject.Find("KitchenDoor").GetComponent("KitchenController"); //get a reference to the script that opens the door
        if (KC == null)
            print("Could not find KC.cs");
    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "MomGhost")
        {
            Col.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Col.gameObject.SetActive(false);
        }
        else if (Col.gameObject.tag == "Player" && Col.transform.position.z > transform.position.z)
        {
            if (KC != null)
                KC.SendMessage("close_Door"); //close the door
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("MomGhost")) //only open if player enters from left side.
        {
            if (KC != null) //gotta make sure that the BRExitScript isn't null, otherwise ERROR
                KC.SendMessage("open_Door");
        }
    }
}

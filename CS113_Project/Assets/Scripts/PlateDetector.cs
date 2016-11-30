using UnityEngine;
using System.Collections;

public class PlateDetector : MonoBehaviour {

    void OnTriggerStay(Collider plate)
    {
        //print("plate placed");
        //print(plate.gameObject.name);
        //print(gameObject.tag);
        if (plate.gameObject.name == gameObject.tag)
        {
            //print("Correct plate placed");
            for (int i = 0; i < 6; i++)
            {
                if (GameControl.control.plates[i].name == plate.gameObject.name)
                {
                    GameControl.control.plates[i].placed = true;
                }
            }
        }
    }
    void OnTriggerExit(Collider plate)
    {
        //print("Plate removed");
        for (int i = 0; i < 6; i++)
        {
            if (GameControl.control.plates[i].name == plate.gameObject.name)
            {
                GameControl.control.plates[i].placed = false;
            }
        }
    }

}

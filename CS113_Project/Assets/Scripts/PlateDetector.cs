using UnityEngine;
using System.Collections;

public class PlateDetector : MonoBehaviour {

    void OnTriggerEnter(Collider plate)
    {
        //print("plate placed");
        //print(plate.gameObject.name);
        //print(gameObject.tag);
        if (plate.gameObject.name == gameObject.tag)
        {
            //print("Correct plate placed");
            for (int i = 0; i < 3; i++)
            {
                if (GameControl.control.plates[i].name == plate.gameObject.name)
                {
                    //print("HERE");
                        GameControl.control.plates[i].placed += 1;
                    
                }
            }
        }
    }
    void OnTriggerExit(Collider plate)
    {
        //print("Plate removed");
        for (int i = 0; i < 3; i++)
        {
            if (GameControl.control.plates[i].name == plate.gameObject.name && GameControl.control.plates[i].placed > 0)
            {
                GameControl.control.plates[i].placed -= 1;
            }
        }
    }

}

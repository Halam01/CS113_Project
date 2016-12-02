using UnityEngine;
using System.Collections;

public class FlashLightController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (GetComponent<Light>().enabled == true)
            {
                GetComponent<Light>().enabled = false;
            }
            else
            {
                GetComponent<Light>().enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (GameObject.Find("Player").GetComponent<FieldOfView>().on == true)
            {
                GameObject.Find("Player").GetComponent<FieldOfView>().on = false;
            }
            else
            {
                GameObject.Find("Player").GetComponent<FieldOfView>().on = true;
            }
        }

    }
}

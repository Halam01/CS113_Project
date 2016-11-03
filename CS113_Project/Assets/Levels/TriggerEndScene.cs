using UnityEngine;
using System.Collections;

public class TriggerEndScene : MonoBehaviour {

    void OnTriggerEnter(Collider Col)
    {
        print("hello");
        if(Col.gameObject.tag == "Player")
        {
            Application.LoadLevel("Scene3");
        }
    }
}

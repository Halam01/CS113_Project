using UnityEngine;
using System.Collections;

public class TriggerChangeScene : MonoBehaviour {

    void OnTriggerEnter(Collider Col)
    {
        print("hello");
        if(Col.gameObject.tag == "Player")
        {
            Application.LoadLevel("Scene4");
        }
    }
}

using UnityEngine;
using System.Collections;

public class TriggerChangeScene : MonoBehaviour {

    void OnTriggerEnter(Collider Col)
    {
        print("Moving to floor2");
        if(Col.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scene3");
            return;
        }
    }
}

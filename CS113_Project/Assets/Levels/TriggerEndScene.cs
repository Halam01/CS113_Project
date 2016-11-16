using UnityEngine;
using System.Collections;

public class TriggerEndScene : MonoBehaviour {

    void OnTriggerEnter(Collider Col)
    {
        print("Moving to floor3");
        if (Col.gameObject.tag == "Player")
        {
            //Application.LoadLevel("Scene3");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scene3");
        }
    }
}

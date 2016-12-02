using UnityEngine;
using System.Collections;

public class TutorialSceneEnd : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scene1");
        }
    }
}

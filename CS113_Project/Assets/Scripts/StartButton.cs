using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialScene");
        }
    }
}

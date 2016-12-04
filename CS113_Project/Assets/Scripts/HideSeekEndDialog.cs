using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSeekEndDialog : MonoBehaviour {


    int len;
    public Texture2D texture;
    bool paused = false;
    bool triggered = false;
    int i = 0;


    void Update()
    {
        if (Input.GetKeyDown("space") && triggered == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
        }
    }

    // Update is called once per frame
    void OnGUI () {
        len = gameObject.GetComponent<GhostMovement>().DestList.Length;
        if(transform.position == gameObject.GetComponent<GhostMovement>().DestList[len -1].position && gameObject.GetComponent<GhostMovement>().hit == true)
        {
            triggered = true;
            paused = true;
            Time.timeScale = 0;
            GUI.Label(new Rect(0, Screen.height * 0.75f, texture.width, texture.height), texture);
        }
	}
}

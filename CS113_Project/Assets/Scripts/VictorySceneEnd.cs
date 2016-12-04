using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySceneEnd : MonoBehaviour {

    public Texture2D texture2;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && GameControl.control.all_set == true)
        {
           UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
        }
    }
}

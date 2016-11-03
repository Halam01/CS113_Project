using UnityEngine;
using System.Collections;

public class WallColorGreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update () {
	
	}
}

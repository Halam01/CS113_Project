using UnityEngine;
using System.Collections;

public class GhostAI1 : MonoBehaviour {

    public bool hit;
    public bool triggered;
    public float moveSpeed = 0.1f;

    void Start()
    {
        hit = false;
        triggered = false;
    }

	
	// Update is called once per frame
	void Update () {
        if (hit)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + new Vector3(0, 0, 100), Time.deltaTime * moveSpeed);
            hit = false;
        }

    }
}

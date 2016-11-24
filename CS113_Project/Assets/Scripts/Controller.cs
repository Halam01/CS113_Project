//Code taken from Sebastian Lague's Field of View Tutorial

using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public float moveSpeed = 6;
    new Rigidbody rigidbody; //added 'new' to remove a warning.
    Camera viewCamera;
    Vector3 velocity;

    Collider pick_up = null;
    int pressed = -1;


    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            pressed++;
            pressed %= 2;
            if (pressed == 0)
            {
                if (pick_up != null)
                {
                    if (pick_up.gameObject.CompareTag("Pick Up"))
                    {
                        pick_up.gameObject.transform.parent = transform;
                    }
                }
            }else
            {
                if (pick_up != null)
                {
                    if (pick_up.gameObject.CompareTag("Pick Up"))
                    {
                        pick_up.gameObject.transform.parent = null;
                    }
                }
            }

        }
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
	}

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        pick_up = other;
    }
    
    void OnTriggerExit(Collider other)
    {
        pick_up = null;
    }
}

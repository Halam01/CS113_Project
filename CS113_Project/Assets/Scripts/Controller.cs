//Code taken from Sebastian Lague's Field of View Tutorial

using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public float moveSpeed = 6;
    new Rigidbody rigidbody; //added 'new' to remove a warning.
    Camera viewCamera;
    Vector3 velocity;

    Collider pick_up = null;
    bool holding = false;


    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;

	}

    void pickup()
    {
        if (holding || pick_up == null)
        { print("Pick up failed: already holding, or no object to pick up."); }
        else
        {
            if (pick_up.gameObject.CompareTag("Pick Up"))
            {
                //picked up an object.
                pick_up.gameObject.transform.parent = transform;
                holding = true;
            }
        }
    }

    void drop()
    {
        if (!holding || pick_up == null)
        { print("Drop failed: not holding an object"); }
        else
        {
            if (pick_up.gameObject.CompareTag("Pick Up"))
            {
                //dropped up an object.
                pick_up.gameObject.transform.parent = null;
                holding = false;
            }
        }
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("pressed space");
            if (!holding) //not holding an object, want to pick up
            {
                pickup();
            }
            else //holding an object, want to drop
            {
                drop();
            }
            //    print("pressed space");
            //    pressed++;
            //    pressed %= 2;
            //    if (pressed == 0)
            //    {
            //        if (pick_up != null)
            //        {
            //            print("picking up");
            //            if (pick_up.gameObject.CompareTag("Pick Up"))
            //            {
            //                pick_up.gameObject.transform.parent = transform;
            //            }
            //        }
            //        else
            //            print("pick-up == null");
            //    } else
            //    {
            //        if (pick_up != null)
            //        {
            //            if (pick_up.gameObject.CompareTag("Pick Up"))
            //            {
            //                print("putting down");
            //                pick_up.gameObject.transform.parent = null;
            //            }
            //            else
            //                print("pickup not pickup");
            //        }
            //    }
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
        //print("Player enter trigger.");
        if (other.gameObject.CompareTag("Pick Up") && !(holding))
            pick_up = other;
    }
    
    void OnTriggerExit(Collider other)
    {
        //print("Player exit trigger.");
        if(other.gameObject.CompareTag("Pick Up") && !(holding))
           pick_up = null;
    }
}

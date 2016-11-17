using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public Rigidbody rdgBdy;
    private Vector3 input;
    private float maxSpeed = 50f; //upped from 15f for testing purposes

    // Use this for initialization
    void Start() {
        rdgBdy = GetComponent<Rigidbody>();

    }


    // Update is called once per frame
    void Update() {

        //Look At Mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        transform.LookAt(mousePos + Vector3.up * transform.position.y);

        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (rdgBdy.velocity.magnitude < maxSpeed)
        {
            rdgBdy.AddForce(input * moveSpeed);
        }

    }



}

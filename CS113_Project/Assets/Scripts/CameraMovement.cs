using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public GameObject player;     
    //private Vector3 offset;         
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //offset = transform.position - player.transform.position;
        //removed offset variable so that way the camera remains at a fixed height of 10
        
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = player.transform.position + offset;
        // Ideally, want to set the camera y position to never change. How?
        transform.position = new Vector3(player.transform.position.x, 10, player.transform.position.z);
    }
}

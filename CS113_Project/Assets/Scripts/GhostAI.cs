using UnityEngine;
using System.Collections;
using System;

public class GhostAI : MonoBehaviour {

    bool on_hit = false;
    double range = 6;
    double angle = 15.0;
    float moveSpeed = 0.1f;

    // Update is called once per frame
    void Update() {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject flashlight = GameObject.FindWithTag("Flashlight");
        Vector3 player_pos = player.transform.position;
        range = (double)(flashlight.GetComponent<Light>().range)-2;
        Vector3 ghost_pos = transform.position;
 
        if (Vector3.Distance(player_pos, ghost_pos) <= range && Vector3.Angle(flashlight.transform.forward, ghost_pos - player_pos) < angle && on_hit == false)
        {
            //transform.Rotate(0, Time.deltaTime * 30, 0, Space.Self);
            // transform.Translate(transform.forward * 100 * Time.deltaTime);
            transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + new Vector3(0, 0, 100), Time.deltaTime * moveSpeed);
           // on_hit = true;
        }
    }

}

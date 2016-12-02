using UnityEngine;
using System.Collections;

public class GRController : MonoBehaviour
{

    bool closed;
    Vector3 closedPos, openPos;

    //used for animating the open/close
    bool midanim;
    bool activated;
    float[] lerp_count; //array of float values (percentages, essentially)
    int lerp_i;

    // Use this for initialization
    void Start()
    {
        closed = true;

        //The vectors for the open and closed door positions
        closedPos = new Vector3(4, 0, 27);
        openPos = new Vector3((float)(5.5), 0, 25);

        activated = false;
        midanim = false;
        lerp_count = new float[] { 0.0f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1f };
        lerp_i = 0;
    }
    //Update that gradually opens the door
    void Update()
    {
        if (midanim) //door in motion
        {
            if (closed)  //in the middle of opening the door
            {
                lerp_i++;
                transform.localPosition = Vector3.Lerp(closedPos, openPos, lerp_count[lerp_i]); //move to next position in 'gradient'
                transform.Rotate(0, 12, 0); //rotate the door slightly to give it swing
                if (lerp_i == 9) //now the door should be fully opened
                {
                    closed = false; //Now the door is open, no longer moving, and not activated
                    midanim = false;
                    activated = false;
                }
            }
            else //in the middle of closing the door, same as opening it
            {
                lerp_i--;
                transform.localPosition = Vector3.Lerp(closedPos, openPos, lerp_count[lerp_i]);
                transform.Rotate(0, -12, 0);
                if (lerp_i == 0)
                {
                    closed = true;
                    midanim = false;
                    activated = false;
                }
            }
        }
        else if (activated)
        {
            midanim = true;
        }
    }
    void close_Door()
    {
        if (!closed)
        {
            activated = true;
        }
    }

    void open_Door()
    {
        if (closed)
        {
            activated = true;
        }
    }
}

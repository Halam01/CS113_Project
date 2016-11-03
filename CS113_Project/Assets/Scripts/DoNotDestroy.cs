using UnityEngine;
using System.Collections;

public class DoNotDestroy : MonoBehaviour {

    public static DoNotDestroy player;

    // Use this for initialization
    void Awake()
    {
        if (player == null)
        {
            DontDestroyOnLoad(this);
            player = this;
        }
        else if (player != this)
        {
            Destroy(this);
        }

    }
}

using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

    public static GameControl control;


    public struct PlateDetector
    {
        public string name;
        public bool placed;
    }

    public PlateDetector[] plates;
    public bool all_set = false;


    // Use this for initialization
    void Awake () {
        if(control == null)
        {
           DontDestroyOnLoad(gameObject);
           control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }  
	}
	
    void Start()
    {
        plates = new PlateDetector[6];
        plates[0].name = "Normal Plate1";
        plates[1].name = "Normal Plate2";
        plates[2].name = "Normal Plate3";
        plates[3].name = "Veggie Plate1";
        plates[4].name = "Veggie Plate2";
        plates[5].name = "NC Plate";
    }

    void Update()
    {
        all_set = true;
        for(int i = 0; i < 6; i++)
        {
            if (plates[i].placed == false)
            {
                //print(plates[i].name);
                all_set = false;
            }
        }
        //print(all_set);
    }
}

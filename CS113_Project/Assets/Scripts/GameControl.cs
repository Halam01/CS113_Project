using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{

    public static GameControl control;


    public struct PlateDetector
    {
        public string name;
        public int placed;
    }

    public PlateDetector[] plates;
    public bool all_set = false;


    // Use this for initialization
    void Awake()
    {
        if (control == null)
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
        plates = new PlateDetector[3];
        plates[0].name = "Normal Plate";
        plates[1].name = "Veggie Plate";
        plates[2].name = "NC Plate";
        plates[0].placed = 0;
        plates[1].placed = 0;
        plates[2].placed = 0;
        /* plates[3].name = "Veggie Plate1";
         plates[4].name = "Veggie Plate2";
         plates[5].name = "NC Plate";
         */
    }

    void Update()
    {
        //print(plates[0].placed);
        //print(plates[1].placed);
        //print(plates[2].placed);
        if (plates[0].placed == 3 && plates[1].placed == 2 && plates[2].placed == 1)
        {
            all_set = true;
        }
        else
        {
            all_set = false;
        }
        /*all_set = true;
        for (int i = 0; i < 6; i++)
        {
            if (plates[i].placed == false)
            {
                //print(plates[i].name);
                all_set = false;
            }
        }
        //print(all_set);
        */
    }
}
    

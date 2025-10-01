using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionaries : MonoBehaviour
{

    public string[] NamesArray = new string[10];

    public Dictionary<string, int> NamesDictionary = new Dictionary<string, int>();
    public Dictionary<bool, int> Practice = new Dictionary<bool, int>();

    public Dictionary<string, int> LevelScores = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        NamesArray[0] = "Farhan";
        NamesArray[1] = "Farhan";
        NamesArray[2] = "Farhan";
        NamesArray[3] = "Farhan";
        NamesArray[4] = "Farhan";
        NamesArray[5] = "Farhan";
        NamesArray[6] = "Farhan";
        NamesArray[7] = "Farhan";
        NamesArray[8] = "Farhan";
        NamesArray[9] = "Farhan";

        NamesDictionary["Farhan"] = 35;
        NamesDictionary["Ghazi"] = 50;
        NamesDictionary["Hamza"] = 150;

        LevelScores["Level 1"] = 100;
        LevelScores["Level 2"] = 80;
        LevelScores["Level 3"] = 70;

        Practice[true] = 1;
        Practice[false] = 0;



        Debug.Log("the value of true is : " + Practice[true]); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

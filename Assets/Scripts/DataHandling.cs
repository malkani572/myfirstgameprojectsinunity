using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataHandling : MonoBehaviour
{
    public TMP_InputField DataInput;
    public TMP_Text DataOutput;
    
    public void SaveData()
    {
        string data = DataInput.text;
        PlayerPrefs.SetString("datakey", data);
    }

    public void LoadData()
    {
        //PlayerPrefs.DeleteKey("datakey");
        string data = PlayerPrefs.GetString("datakey", "No Data Save");
        DataOutput.text = data;

        if(PlayerPrefs.HasKey("datakey"))
        {
            Debug.Log("Datakey is present");
        }
        if (PlayerPrefs.HasKey("datakeyasdasd"))
        {
            Debug.Log("it is present");
        }
        else
        {
            Debug.Log("Above key not present");
        }

    }
}

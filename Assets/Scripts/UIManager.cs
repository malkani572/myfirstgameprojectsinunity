using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text SelectedThemeNameText;

    string CurrentThemeName = "Light";

    public UIHandler[] ButtonsUI;
    // Start is called before the first frame update
    void Start()
    {

        CurrentThemeName = PlayerPrefs.GetString(theme_name_key,"Black");
        SelectedThemeNameText.text = CurrentThemeName;
        UpdateButtonUIHandler();
        Debug.Log("Current theme is: " + CurrentThemeName);
    }

    string theme_name_key = "CurrentThemeName";


    public void ChangeUITheme()
    {
        if (CurrentThemeName == "Dark")
        {
            CurrentThemeName = "Light";
        }
        else
        {
            CurrentThemeName = "Dark";
        }
        PlayerPrefs.SetString(theme_name_key, CurrentThemeName);

        SelectedThemeNameText.text = CurrentThemeName;

       UpdateButtonUIHandler();
        Debug.Log("Theme Changed; " + PlayerPrefs.GetString(theme_name_key));
    }

    void UpdateButtonUIHandler()
    {
        for (int i = 0; i < ButtonsUI.Length; i++)
        {
            ButtonsUI[i].ChangedUI(CurrentThemeName);
        }
    }
}

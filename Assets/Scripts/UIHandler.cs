using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Sprite DarkUISprite;
    public Sprite LightUISprite;

    Image ImageComponent;

    private void Awake()
    {
        ImageComponent = GetComponent<Image>();
    }


    public void ChangedUI(string theme_name)
    {
        //if (theme_name == "Dark")
        //    ImageComponent.sprite = DarkUISprite;
        //else
        //    ImageComponent.sprite = LightUISprite;

        ImageComponent.sprite = theme_name == "Dark" ? DarkUISprite : LightUISprite;
    }

   
}

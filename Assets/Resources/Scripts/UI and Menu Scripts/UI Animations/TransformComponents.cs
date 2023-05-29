using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TransformComponents
{
    public Transform transform;

    public Text Text
    {
        get
        {
            return transform.GetComponentInChildren<Text>();
        }
    }
    public Color TextColor
    {
        get
        {
            return transform.GetComponentInChildren<Text>().color;
        }

        set
        {

        }
    }
    public Color ShadowColor
    {
        get
        {
            return transform.GetComponentInChildren<Shadow>().effectColor;
        }

        set
        {

        }
    }
    public Color OutlineColor
    {
        get
        {
            return transform.GetComponentInChildren<Outline>().effectColor;
        }

        set
        {

        }
    }
}

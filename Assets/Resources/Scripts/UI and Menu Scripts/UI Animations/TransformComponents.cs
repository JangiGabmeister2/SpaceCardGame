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
            transform.GetComponentInChildren<Text>().color = value;
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
            transform.GetComponentInChildren<Shadow>().effectColor = value;
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
            transform.GetComponentInChildren<Outline>().effectColor = value;
        }
    }
    public Vector2 OriginalPosition
    {
        get
        {
            return transform.position;
        }
    }
    public Vector2 position
    {
        get
        {
            return transform.position;
        }

        set
        {
            transform.position = value;
        }
    }
    public Vector2 localPosition
    {
        get
        {
            return transform.localPosition;
        }

        set
        {
            transform.localPosition = value;
        }
    }
}

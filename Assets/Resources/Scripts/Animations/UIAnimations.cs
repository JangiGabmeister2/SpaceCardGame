using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    [SerializeField] private GameObject fadePanel;

    private void Start()
    {
        LeanTween.color(fadePanel, new Color(0, 0, 0, 0), Time.deltaTime);
    }
}

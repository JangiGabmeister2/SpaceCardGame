//CONNECT SCRIPT TO GAMEOBJECT WITH HOLOGRAM MATERIAL

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HologramGlitchEffect : MonoBehaviour
{
    private Material holoMaterial;

    [Header("Texture")]
    public Vector2 hologramTextureTiling = new Vector2(1, 1);
    public float scanLineOffset;
    public float scrollSpeed = 0.05f;

    [Header("Fresnel Shading")]
    public float fresnelStrength = 2.9f;
    public Color fresnelColor = new Color(255, 255, 255, 0);
    public Color hologramColor = new Color(255, 255, 255, 0);

    [Header("Hologram Noise Control")]
    public float glitchStrength;
    public int noiseScale = 500;
    public float noiseStrength = 0.06f;

    private void Start()
    {
        holoMaterial = GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void Update()
    {
        holoMaterial.SetVector("_Hologram_Tiling", hologramTextureTiling);

        holoMaterial.SetFloat("_Scanline_Offset", scanLineOffset);
        holoMaterial.SetFloat("_Scroll_Speed", scrollSpeed);
        holoMaterial.SetFloat("_Fresnel_Strength", fresnelStrength);

        holoMaterial.SetColor("_Fresnel_Color", fresnelColor);
        holoMaterial.SetColor("_MainColor", hologramColor);

        holoMaterial.SetFloat("_Glitch_Strength", glitchStrength);
        holoMaterial.SetFloat("_Noise_Scale", noiseScale);
        holoMaterial.SetFloat("_Noise_Strength", noiseStrength);
    }
}

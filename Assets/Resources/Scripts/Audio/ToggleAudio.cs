using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudio : MonoBehaviour
{
    private bool isMuted = false;

    [SerializeField] private Button button;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Sprite muteSprite, unMuteSprite;

    private void Start()
    {
        audioSource.mute = false;

        button.image.sprite = unMuteSprite;
    }

    private void Update()
    {
        if (isMuted)
        {
            audioSource.mute = true;

            button.image.sprite = muteSprite;
        }
        else
        {
            audioSource.mute = false;

            button.image.sprite = unMuteSprite;
        }
    }

    public void MuteSounds()
    {
        isMuted = !isMuted;
    }
}

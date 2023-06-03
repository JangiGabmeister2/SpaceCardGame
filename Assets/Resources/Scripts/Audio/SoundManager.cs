using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Sound Manager Instance
    private static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Sound Manager instance already exists. Destroying component.");
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] AudioSource musicSource, effectsSource;

    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }

    public void ControlVolume(float value)
    {
        musicSource.volume = value;
    }

    public void ChangeMusic(AudioClip clip)
    {
        musicSource.Stop();
        musicSource.PlayOneShot(clip);
    }
}

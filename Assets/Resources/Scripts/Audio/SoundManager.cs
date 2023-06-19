using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    #region Sound Manager Instance
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Sound Manager instance already exists. Destroying duplicate!");
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] AudioSource musicSource, effectsSource;    

    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }

    public void ControlMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void ControlEffectsVolume(float volume)
    {
        effectsSource.volume = volume;
    }

    public void ChangeMusic(AudioClip clip)
    {
        musicSource.Stop();
        musicSource.PlayOneShot(clip);
    }
}

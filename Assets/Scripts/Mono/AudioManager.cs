using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _soundsSource;
    [SerializeField] private AudioClip _letterClickClip;
    [SerializeField] private AudioClip _menuClickClip;

    private void OnEnable()
    {
        LetterButton.OnLetterClicked += PlayLetterClickSound;
        LevelButtonController.OnButtonClicked += PlayMenuClickSound;
    }

    private void PlayLetterClickSound()
    {
        _soundsSource.PlayOneShot(_letterClickClip);
    }
    
    private void PlayMenuClickSound()
    {
        _soundsSource.PlayOneShot(_menuClickClip);
    }
}

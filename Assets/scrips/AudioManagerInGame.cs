using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public void ToggleMusicMute(bool isMuted)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.MuteMusic(isMuted);
        }
    }

    public void ToggleSFXMute(bool isMuted)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.MuteSFX(isMuted);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetMusicVolume(volume);
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetSFXVolume(volume);
        }
    }
}
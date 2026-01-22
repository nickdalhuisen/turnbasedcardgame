using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public List<SoundEffects> soundEffects;

    public AudioSource AudioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    public void Play(string label)
    {
        SoundEffects sfx = soundEffects.Find(s => s.label == label);
        if (sfx != null)
        {
            if (sfx.effect != null)
            {
                AudioSource.PlayOneShot(sfx.effect);
            }
        }
    }

}


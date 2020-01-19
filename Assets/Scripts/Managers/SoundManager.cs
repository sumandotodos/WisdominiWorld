using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySoundSafe(AudioClip clip)
    {
        if(clip != null)
        {
            Instance.audioSource.PlayOneShot(clip);
        }
    }

    public static void PlaySoundSetSafe(AudioClipSet set)
    {
        if(set != null)
        {
            PlaySoundSafe(set.Get());
        }
    }

}

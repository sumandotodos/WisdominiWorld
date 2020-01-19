using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipSet : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioClip Get()
    {
        int r = Random.Range(0, clips.Length - 1);
        return clips[r];
    }
}

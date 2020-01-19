using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessClock : MonoBehaviour
{
    public Clock[] Clocks;
    public AudioClipSet PingAudio;
    int RunningClock = 0;

    void Start()
    {
        foreach (Clock clock in Clocks)
        {
            clock.TimeUp += StopAll;
        }
    }

    public void StopAll()
    {
        foreach(Clock clock in Clocks)
        {
            clock.Stop();
        }
    }

    public void Reset()
    {
        RunningClock = 0;
        foreach (Clock clock in Clocks)
        {
            clock.Reset();
        }
    }

    public void Go()
    {
        for(int i = 0; i < Clocks.Length; ++i)
        {
            if(i == RunningClock)
            {
                Clocks[i].Go();
            }
            else
            {
                Clocks[i].Stop();
            }
        }
    }

    public void Switch()
    {
        SoundManager.PlaySoundSetSafe(PingAudio);
        RunningClock = (RunningClock + 1) % Clocks.Length;
        Go();
    }

}

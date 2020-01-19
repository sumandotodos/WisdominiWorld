using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public int Seconds = 50;
    int RemainSeconds;
    System.Action StateUpdate;
    public System.Action TimeUp;
    float Remain = 1.0f;
    public Transform Needle;
    public AudioClipSet TickAudio;
    public AudioClipSet RingAudio;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    private void SetNeedleToSeconds(int Secs)
    {
        float FloatSecs = (float)Secs;
        Needle.localRotation = Quaternion.Euler(new Vector3(0, 0, -(90.0f / 15.0f) * FloatSecs));
    }

    // Update is called once per frame
    void Update()
    {
        StateUpdate();
    }

    public void IdleUpdate()
    {
        // Nothing here
    }

    public void Go()
    {
        StateUpdate = TickingUpdate;
    }

    public void TickingUpdate()
    {
        Remain -= Time.deltaTime;
        if(Remain <= 0.0f)
        {
            Remain = 1.0f;
            SoundManager.PlaySoundSetSafe(TickAudio);
            --RemainSeconds;
            SetNeedleToSeconds(RemainSeconds);
            if(RemainSeconds == 0)
            {
                SoundManager.PlaySoundSetSafe(RingAudio);
                if(TimeUp != null)
                {
                    TimeUp();
                }
                StateUpdate = Ringing;
                Remain = 2.0f;
            }
        }
    }

    public void Ringing()
    {
        Remain -= Time.deltaTime;
    }

    public void Reset()
    {
        StateUpdate = IdleUpdate;
        Remain = 1.0f;
        RemainSeconds = Seconds;
        SetNeedleToSeconds(RemainSeconds);
    }

    public void Stop()
    {
        StateUpdate = IdleUpdate;
    }
}

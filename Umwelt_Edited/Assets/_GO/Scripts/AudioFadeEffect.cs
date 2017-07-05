using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeEffect : FadeBase
{

    public override void Update()
    {
        base.Update();
    }

    public override void FadeOut()
    {
        base.FadeOut();
        foreach (var audioClip in AudioController.Instance.AudioClips)
        {
            audioClip.Source.volume = _timer.Ratio;
        }
    }

    public override void FadeIn()
    {
        base.FadeIn();
        foreach(var audioClip in AudioController.Instance.AudioClips)
        {
            audioClip.Source.volume = 1 - _timer.Ratio;
        }
    }
}

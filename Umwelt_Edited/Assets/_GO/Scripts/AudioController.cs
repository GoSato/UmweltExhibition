using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum FrequencyType
{
    High,
    Middle,
    Low
}

public enum SourceType
{
    Mono,
    Stereo
}

[System.Serializable]
public class AudioInfo
{
    public FrequencyType Type;
    public Transform Target;
    public GameObject AudioObject;
    public AudioClip Mono;
    public AudioClip Stereo;
    [HideInInspector]
    public AudioSource Source;
}

public class AudioController : SingletonMonoBehavior<AudioController>
{
    [SerializeField]
    private List<AudioInfo> _audioClips = new List<AudioInfo>();
    public List<AudioInfo> AudioClips { get { return _audioClips; } }

    private AudioFadeEffect _effect;

    override protected void Awake()
    {
        base.Awake();
        foreach (var audio in _audioClips)
        {
            SpawnAudioObject(audio);
        }

        _effect = GetComponent<AudioFadeEffect>();
    }

    /// <summary>
    /// Targetの位置にAudioObjectを生成
    /// </summary>
    /// <param name="audio"></param>
    private void SpawnAudioObject(AudioInfo audio)
    {
        var gameObject = Instantiate(audio.AudioObject, audio.Target);
        var audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audio.Stereo;
        audio.Source = audioSource;
    }

    /// <summary>
    /// 指定された音源を再生
    /// </summary>
    /// <param name="type"></param>
    private void Play(FrequencyType type)
    {
        var audioClip = _audioClips.Where(a => a.Type == type);
        foreach (var audio in audioClip)
        {
            audio.Source.Play();
        }
    }

    /// <summary>
    /// 指定された音源を停止
    /// </summary>
    /// <param name="type"></param>
    public void Stop(FrequencyType type)
    {
        var audioClip = _audioClips.Where(a => a.Type == type);
        foreach (var audio in audioClip)
        {
            audio.Source.Stop();
        }
    }

    /// <summary>
    /// 指定された音源の音量を変更
    /// </summary>
    /// <param name="type"></param>
    /// <param name="volume"></param>
    public void ChangeVolume(FrequencyType type, float volume)
    {
        var audioClip = _audioClips.Where(a => a.Type == type);
        foreach (var audio in audioClip)
        {
            audio.Source.volume = volume;
        }
    }

    /// <summary>
    /// 登録されている全ての音源を再生
    /// </summary>
    public void PlayAll()
    {
        foreach (var audio in _audioClips)
        {
            audio.Source.Play();
        }
        _effect.FadeStart(FadeType.FadeIn);
    }

    /// <summary>
    /// 登録されている全ての音源を停止
    /// </summary>
    public void StopAll()
    {
        _effect.FadeStart(FadeType.FadeOut);
        StartCoroutine(StopAllCoroutine());
    }

    private IEnumerator StopAllCoroutine()
    {
        yield return new WaitForSeconds(_effect.FadeOutTime);

        foreach (var audio in _audioClips)
        {
            audio.Source.Stop();
        }
    }

    /// <summary>
    /// 音源をStereo or Monoに切り替える
    /// </summary>
    /// <param name="fType"></param>
    /// <param name="sType"></param>
    public void ChangeSourceType(FrequencyType fType, SourceType sType)
    {
        var audioClip = _audioClips.Where(a => a.Type == fType);
        foreach (var audio in audioClip)
        {
            switch (sType)
            {
                case SourceType.Mono:
                    audio.Source.clip = audio.Mono;
                    break;
                case SourceType.Stereo:
                    audio.Source.clip = audio.Stereo;
                    break;
                default:
                    break;
            }
            audio.Source.Play();
        }
    }

    public void EnableImage(FrequencyType type)
    {
        var audioClip = _audioClips.Where(a => a.Type == type);
        foreach (var audio in audioClip)
        {
            audio.Source.GetComponent<IAudioObject>().Image.color = new Color(1, 1, 1, 1);
        }
    }

    public void DisableImage(FrequencyType type)
    {
        var audioClip = _audioClips.Where(a => a.Type == type);
        foreach (var audio in audioClip)
        {
            audio.Source.GetComponent<IAudioObject>().Image.color = new Color(0, 0, 0, 0);
        }
    }
}

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

    private List<AudioSource> _audioSources = new List<AudioSource>();
    public List<AudioSource> AudioSources { get { return _audioSources; } }

    void Start()
    {
        foreach (var audio in _audioClips)
        {
            SpawnAudioObject(audio);
        }
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
    /// 登録されている全ての音源を再生
    /// </summary>
    public void PlayAll()
    {
        foreach(var audio in _audioClips)
        {
            audio.Source.Play();
        }
    }

    /// <summary>
    /// 登録されている全ての音源を停止
    /// </summary>
    public void StopAll()
    {
        foreach (var audio in _audioClips)
        {
            audio.Source.Stop();
        }
    }

    public void ChangeSourceType(FrequencyType fType, SourceType sType)
    {
        var audioClip = _audioClips.Where(a => a.Type == fType) as AudioInfo;
        switch (sType)
        {
            case SourceType.Mono:
                audioClip.Source.clip = audioClip.Mono;
                break;
            case SourceType.Stereo:
                audioClip.Source.clip = audioClip.Stereo;
                break;
            default:
                break;
        }
    }
}

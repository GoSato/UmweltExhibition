using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioInfo
{
    public Transform Target;
    public GameObject AudioObject;
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
        _audioSources.Add(audioSource);
    }

    /// <summary>
    /// 登録されている全ての音源を再生
    /// </summary>
    public void PlayAll()
    {
        foreach(var audio in _audioSources)
        {
            audio.Play();
        }
    }

    /// <summary>
    /// 登録されている全ての音源を停止
    /// </summary>
    public void StopAll()
    {
        foreach (var audio in _audioSources)
        {
            audio.Stop();
        }
    }
}

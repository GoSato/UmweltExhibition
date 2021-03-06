﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerBehaviour : MonoBehaviour
{
    private VideoPlayer _video;

    void Start()
    {
        _video = GetComponent<VideoPlayer>();
    }

    public void PlayVideo()
    {
        _video.Play();
    }

    public void StopVideo()
    {
        _video.Stop();
    }
}

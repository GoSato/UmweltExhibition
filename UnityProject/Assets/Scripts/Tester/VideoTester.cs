using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTester : MonoBehaviour
{
    private VideoPlayerBehaviour _videoPlayer;

    void Start()
    {
        _videoPlayer = FindObjectOfType<VideoPlayerBehaviour>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _videoPlayer.PlayMove();
        }
    }
}

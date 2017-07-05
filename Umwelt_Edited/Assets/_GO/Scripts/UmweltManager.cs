using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmweltManager : GameManagerBase
{
    [SerializeField]
    private float _restartTime = 3f;

    private SkyboxFader _skyboxFader;
    private VideoPlayerBehaviour _video;

    public override void Start()
    {
        base.Start();
        _skyboxFader = FindObjectOfType<SkyboxFader>();
        _video = FindObjectOfType<VideoPlayerBehaviour>();
    }

    public override void DoStartAction()
    {
        base.DoStartAction();
    }

    public override void DoPrepareAction()
    {
        base.DoPrepareAction();
    }

    public override void DoPlayingAction()
    {
        base.DoPlayingAction();
        AudioController.Instance.PlayAll();
        _skyboxFader.FadeStart(FadeType.FadeIn);
        //_video.PlayVideo();
    }

    public override void DoEndAction()
    {
        base.DoEndAction();
        AudioController.Instance.StopAll();
        _skyboxFader.FadeStart(FadeType.FadeOut);
        StartCoroutine(RestartCoroutine());
        //_video.StopVideo();
    }

    private IEnumerator RestartCoroutine()
    {
        yield return new WaitForSeconds(_restartTime);
        SetCurrentState(GameState.Start);
    }
}

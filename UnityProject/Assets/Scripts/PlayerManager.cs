using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    High,
    Middle,
    Low,
    None,
}

public class PlayerManager : SingletonMonoBehavior<PlayerManager>
{
    private PlayerState _currentPlayerState = PlayerState.Middle;
    public PlayerState CurrentPlayerState { get { return _currentPlayerState; } }

    void Start()
    {
        SetCurrentState(PlayerState.Middle);
    }

    public void SetCurrentState(PlayerState state)
    {
        if(state == _currentPlayerState)
        {
            return;
        }

        _currentPlayerState = state;
        OnPlayerStateChanged(_currentPlayerState);
    }

    private void OnPlayerStateChanged(PlayerState state)
    {
        switch(state)
        {
            case PlayerState.High:
                DoHighAciton();
                break;
            case PlayerState.Middle:
                DoMiddleAction();
                break;
            case PlayerState.Low:
                DoLowAction();
                break;
            default:
                break;
        }
    }

    public void DoHighAciton()
    {
        AudioController.Instance.ChangeVolume(FrequencyType.High, 1f);
        AudioController.Instance.ChangeVolume(FrequencyType.Low, 0f);
    }

    public void DoMiddleAction()
    {
        AudioController.Instance.ChangeVolume(FrequencyType.High, 1f);
        AudioController.Instance.ChangeVolume(FrequencyType.Low, 1f);
    }

    public void DoLowAction()
    {
        AudioController.Instance.ChangeVolume(FrequencyType.High, 0f);
        AudioController.Instance.ChangeVolume(FrequencyType.Low, 1f);
    }
}

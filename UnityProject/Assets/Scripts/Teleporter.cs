using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : RayIrradiatorBase
{
    [SerializeField]
    private float _readyTime;

    private bool _isReadyTeleport = false;
    private Timer _timer = new Timer();
    private Transform _target;

    void Update()
    {
        if (_isReadyTeleport)
        {
            if (_timer.Update())
            {
                _isReadyTeleport = false;
                Teleport();
            }
            else
            {
                // TODO : add any feedback
                //Debug.Log(_timer.RemainingTime);
                //_hitObj.transform.Find("ScalingCircle").transform.localScale = Vector3.one * (1 - _timer.Ratio);
            }
        }
    }

    public override void RayHit()
    {
        base.RayHit();
        if (PlayerManager.Instance.CurrentPlayerState == PlayerState.Middle)
        {
            ReadyTeleport();
        }
        else
        {
            if(_hitObj.GetComponentInChildren<IAudioObject>().Type == FrequencyType.Middle)
            {
                ReadyTeleport();
            }
        }
    }

    public override void RayOut()
    {
        base.RayOut();
        CancelTeleport();
    }

    /// <summary>
    /// テレポート待機状態
    /// 指定秒数後テレポート
    /// </summary>
    private void ReadyTeleport()
    {
        _timer.LimitTime = _readyTime;
        _timer.IsEnable = true;
        _target = _hitObj.transform;
        _isReadyTeleport = true;
    }

    /// <summary>
    /// テレポート待機状態をキャンセル
    /// </summary>
    private void CancelTeleport()
    {
        _target = null;
        _timer.IsEnable = false;
        _isReadyTeleport = false;
    }

    /// <summary>
    /// ターゲットの位置に移動
    /// </summary>
    private void Teleport()
    {
        transform.root.transform.position = _target.position;

        var state = ConvertState();
        PlayerManager.Instance.SetCurrentState(state);
    }

    /// <summary>
    /// ターゲットになっているAudioObjectのtypeをstateに変換
    /// </summary>
    /// <returns></returns>
    private PlayerState ConvertState()
    {
        var type = _target.GetComponentInChildren<IAudioObject>().Type;

        switch (type)
        {
            case FrequencyType.High:
                return PlayerState.High;
                break;
            case FrequencyType.Middle:
                return PlayerState.Middle;
                break;
            case FrequencyType.Low:
                return PlayerState.Low;
                break;
            default:
                return PlayerState.None;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : RayIrradiatorBase
{
    [SerializeField]
    private float _readyTime;
    [SerializeField]
    private Transform _cameraParent;

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
        if (UmweltManager.Instance.CurrentGameState == GameState.Playing)
        {
            ReadyTeleport();
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

    private void Teleport()
    {
        _cameraParent.position = new Vector3(_target.position.x, _cameraParent.position.y, _target.position.z);
        _cameraParent.transform.parent = _target.transform;
    }
}

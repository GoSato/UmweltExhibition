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
            }
        }
    }

    public override void RayHit()
    {
        base.RayHit();
        ReadyTeleport();
    }

    public override void RayOut()
    {
        base.RayOut();
        CancelTeleport();
    }

    private void ReadyTeleport()
    {
        _timer.LimitTime = _readyTime;
        _timer.IsEnable = true;
        _target = _hitObj.transform;
        _isReadyTeleport = true;
    }

    private void CancelTeleport()
    {
        _target = null;
        _timer.IsEnable = false;
        _isReadyTeleport = false;
    }

    private void Teleport()
    {
        transform.position = _target.position;
    }
}

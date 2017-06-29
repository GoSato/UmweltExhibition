using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartSwitchBehaviour : MonoBehaviour
{
    private bool _isStarted = false;
    private float _elapsedTime;
    private float _checkTime;
    private Action checkEndAction; 

    void Update()
    {
        if (_checkTime != 0)
        {
            CheckElapsedTime();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(_isStarted && IsCamera(other))
        {
            EndPrepare();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(!_isStarted && IsCamera(other))
        {
            StartPrepare();
        }
    }

    private void StartPrepare()
    {
        SetCheckTime(3f);
        checkEndAction = OnStart;
    }

    private void EndPrepare()
    {
        SetCheckTime(3f);
        checkEndAction = OnEnd;
    }

    private void OnStart()
    {
        Debug.Log("Start");
        _isStarted = true;
    }

    private void OnEnd()
    {
        Debug.Log("End");
        _isStarted = false;
    }

    /// <summary>
    /// 衝突したオブジェクトがカメラ(HMD)かどうか
    /// </summary>
    /// <param name="col"></param>
    /// <returns></returns>
    private bool IsCamera(Collider col)
    {
        if(col.transform.parent.GetComponentInChildren<Camera>() != null)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// チェックする時間を設定
    /// </summary>
    /// <param name="time"></param>
    private void SetCheckTime(float time)
    {
        _checkTime = time;
    }

    /// <summary>
    /// 経過時間を観察する
    /// </summary>
    private void CheckElapsedTime()
    {
        if (_elapsedTime > _checkTime)
        {
            _elapsedTime = 0;
            _checkTime = 0;
            checkEndAction.Invoke();
            checkEndAction = null;
        }
        else
        {
            _elapsedTime += Time.deltaTime;
        }
    }
}

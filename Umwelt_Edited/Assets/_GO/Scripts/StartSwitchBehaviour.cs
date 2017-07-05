using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartSwitchBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _waitTime;

    private bool _isStarted = false;
    private float _elapsedTime;
    private float _checkTime;
    private Action checkEndAction;

    void Start()
    {
        UmweltManager.Instance.SetCurrentState(GameState.Start);
    }

    void Update()
    {
        if (_checkTime != 0)
        {
            CheckElapsedTime();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (UmweltManager.Instance.CurrentGameState == GameState.Playing && IsCamera(other))
        {
            EndPrepare();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(UmweltManager.Instance.CurrentGameState == GameState.Start && IsCamera(other))
        {
            StartPrepare();
        }
    }

    private void StartPrepare()
    {
        UmweltManager.Instance.SetCurrentState(GameState.Prepare);
        SetCheckTime(_waitTime);
        checkEndAction = OnStart;
    }

    private void EndPrepare()
    {
        SetCheckTime(_waitTime);
        checkEndAction = OnEnd;
    }

    private void OnStart()
    {
        Debug.Log("Start");
        UmweltManager.Instance.SetCurrentState(GameState.Playing);
        checkEndAction = null;
    }

    private void OnEnd()
    {
        Debug.Log("End");
        UmweltManager.Instance.SetCurrentState(GameState.End);
        checkEndAction = null;
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

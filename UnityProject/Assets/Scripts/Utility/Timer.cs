using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    /// <summary>
    /// 経過時間
    /// </summary>
    public float CurrentTime
    {
        get;
        private set;
    }
    
    /// <summary>
    /// 残り時間
    /// </summary>
    public float RemainingTime
    {
        get
        {
            return LimitTime - CurrentTime;
        }
        private set
        {

        }
    }

    /// <summary>
    /// 停止時間
    /// </summary>
    public float LimitTime
    {
        get;
        set;
    }

    /// <summary>
    /// LimitTimeまで時間が進んだら呼ばれる
    /// </summary>
    public Delegate.VoidDelegate FireDelegate
    {
        get;
        set;
    }

    /// <summary>
    /// タイマーを使用中か
    /// </summary>
    private bool _isEnable = true;
    public bool IsEnable
    {
        get
        {
            return _isEnable;
        }
        set
        {
            _isEnable = value;
            if(!value)
            {
                CurrentTime = 0;
            }
        }
    }

    public float Ratio
    {
        get
        {
            return RemainingTime / LimitTime;
        }
        private set
        {

        }
    }

    /// <summary>
    /// 指定時間たったらTrueを返す
    /// </summary>
    /// <returns></returns>
    public bool Update()
    {
        if(IsEnable)
        {
            CurrentTime += Time.deltaTime;
            if(CurrentTime >= LimitTime)
            {
                CurrentTime = 0;
                if(FireDelegate != null)
                {
                    FireDelegate();
                }
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }
}

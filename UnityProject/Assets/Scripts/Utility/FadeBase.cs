using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBase : MonoBehaviour
{
    [SerializeField]
    private float _fadeOutTime;
    public float FadeOutTime { get { return _fadeInTime; } }

    [SerializeField]
    private float _fadeInTime;
    public float FadeInTime { get { return _fadeInTime; } }

    protected Timer _timer = new Timer();
    private Delegate.VoidDelegate FadeImpl;

    private bool _isEnableFade = false;
    public bool IsEnableFade { get { return _isEnableFade; } }

    public virtual void Update()
    {
        if (_isEnableFade)
        {
            if (_timer.Update())
            {
                _isEnableFade = false;
            }
            else
            {
                FadeImpl();
            }
        }
    }

    /// <summary>
    /// フェード処理開始
    /// </summary>
    public void FadeStart(FadeType type)
    {
        if(IsEnableFade)
        {
            return;
        }

        switch(type)
        {
            case FadeType.FadeOut:
                _timer.LimitTime = _fadeOutTime;
                FadeImpl = FadeOut;
                break;
            case FadeType.FadeIn:
                _timer.LimitTime = _fadeInTime;
                FadeImpl = FadeIn;
                break;
            default:
                break;
        }
           
        _isEnableFade = true;
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    public virtual void FadeOut()
    {
    }

    /// <summary>
    /// フェードイン
    /// </summary>
    public virtual void FadeIn()
    {
    }
}

public enum FadeType
{
    FadeOut, FadeIn
}
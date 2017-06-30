using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Skyboxを使用した明転、暗転用のクラス
/// </summary>
public class SkyboxFader : FadeBase
{
    private Material _skybox;
    private float _maxValue;

    void Start()
    {
        _skybox = RenderSettings.skybox;
        _maxValue = _skybox.GetFloat("_Exposure");
    }

    public override void Update()
    {
        // TODO : This is testcode.
        if (!IsEnableFade)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeStart(FadeType.FadeOut);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                FadeStart(FadeType.FadeIn);
            }
        }

        base.Update();
    }

    public override void FadeOut()
    {
        base.FadeOut();
        _skybox.SetFloat("_Exposure", _maxValue * _timer.Ratio);
    }

    public override void FadeIn()
    {
        base.FadeIn();
        _skybox.SetFloat("_Exposure", _maxValue * (1 - _timer.Ratio));
    }

    /// <summary>
    /// 実行終了時にSkyboxに割り当てられているMaterialのパラメーターを元に戻す
    /// </summary>
    private void OnApplicationQuit()
    {
        _skybox.SetFloat("_Exposure", _maxValue);
    }
}

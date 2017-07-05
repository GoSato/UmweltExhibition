using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class PositionCalibrator : MonoBehaviour
{
    [SerializeField]
    private Transform _goal; // 動かす先
    [SerializeField]
    private Transform _target; // 動かしたいオブジェクト
    [SerializeField]
    private Transform _parent;
    [SerializeField]
    private SteamVR_TrackedController _controller;
    [SerializeField]
    private bool _isCalibrateRotation = false;
    [SerializeField]
    private bool _isContinue = false;

    private void Start()
    {
#if UNITY_STANDALONE_WIN
        if(_controller != null)
        {
            _controller.MenuButtonClicked += OnMenuButtonClicked;
        }
#elif UNITY_ANDROID
        //if (HandController.Instance != null)
        //{
        //    HandController.Instance.OnAppButtonDown.AddListener(OnPadClicked);
        //}
#endif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_isCalibrateRotation)
            {
                CalibrateRotation();
            }
            CalibratePosition();
        }

        if (_isContinue)
        {
            CalibratePosition();
        }
    }

    private void CalibratePosition()
    {
        var offset = _target.position - _goal.position;

        if (_parent != null)
        {
            _parent.position -= offset;
        }
        else
        {
            _target.position -= offset;
        }
    }

    private void CalibrateRotation()
    {
        var angle = Vector3.Angle(_target.transform.forward, _goal.transform.forward);
        angle *= (_target.transform.forward - _goal.transform.forward).x > 0 ? 1 : -1;
        _parent.transform.Rotate(new Vector3(0, 1, 0), -angle);
    }

    private void OnMenuButtonClicked(object sender, ClickedEventArgs e)
    {
        if (_isCalibrateRotation)
        {
            CalibrateRotation();
        }
        CalibratePosition();
    }

    private void OnPadClicked()
    {
        if (_isCalibrateRotation)
        {
            CalibrateRotation();
        }
        CalibratePosition();
    }
}

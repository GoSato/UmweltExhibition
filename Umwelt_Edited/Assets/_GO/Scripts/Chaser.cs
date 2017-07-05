using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ターゲットを追跡するためのクラス
/// </summary>
public class Chaser : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _speed;

    private bool _isChased = false;

    /// <summary>
    /// ターゲットとの距離の2乗の値
    /// </summary>
    public float SqrDistance
    {
        get
        {
            return (_target.position - transform.position).sqrMagnitude;
        }
        private set
        {

        }
    }

    void Update()
    {
        if (_isChased)
        {
            var minDistance = 0.1f;
            if (SqrDistance > minDistance * minDistance)
            {
                Chase();
            }
        }
    }

    /// <summary>
    /// 追跡をスタート
    /// </summary>
    [ContextMenu("StartChase")]
    public void StartChase()
    {
        _isChased = true;
    }

    /// <summary>
    /// 追跡
    /// </summary>
    private void Chase()
    {
        var direction = (_target.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime * _speed;
    }
}

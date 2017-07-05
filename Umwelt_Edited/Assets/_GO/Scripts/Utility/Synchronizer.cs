using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Synchronizer : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    void Start()
    {
        var audioObject = _target.GetComponentInChildren<IAudioObject>();
        audioObject.Image = GetComponent<RawImage>();
    }

    void Update()
    {
        transform.position = _target.position;
        transform.rotation = _target.rotation;
    }
}

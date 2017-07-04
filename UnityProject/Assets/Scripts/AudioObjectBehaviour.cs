using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObjectBehaviour : MonoBehaviour, IAudioObject
{
    [SerializeField]
    private FrequencyType _type;

    public FrequencyType Type
    {
        get
        {
            return _type;
        }

        set
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        {
            //AudioController.Instance.ChangeSourceType(_type, SourceType.Mono);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(IsPlayer(other))
        {
            //AudioController.Instance.ChangeSourceType(_type, SourceType.Stereo);
        }
    }

    private bool IsPlayer(Collider other)
    {
        if(other.tag == "Player")
        {
            return true;
        }
        return false;
    }
}

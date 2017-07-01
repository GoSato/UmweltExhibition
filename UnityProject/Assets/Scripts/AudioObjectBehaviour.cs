using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObjectBehaviour : MonoBehaviour
{
    [SerializeField]
    private FrequencyType _type;

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        {
            AudioController.Instance.ChangeSourceType(_type, SourceType.Mono);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(IsPlayer(other))
        {
            AudioController.Instance.ChangeSourceType(_type, SourceType.Stereo);
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

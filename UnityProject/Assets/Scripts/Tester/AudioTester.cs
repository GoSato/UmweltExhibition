using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTester : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioController.Instance.PlayAll();
        }
    }
}

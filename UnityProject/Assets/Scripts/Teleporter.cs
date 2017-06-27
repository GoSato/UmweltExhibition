using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : RayIrradiatorBase
{
    void Update()
    {
        if(_hitObj != null)
        {
            // TODO : This is test input function.
            if(Input.GetKeyDown(KeyCode.Space))
            {
                transform.position = _hitObj.transform.position;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RayIrradiatorBase : MonoBehaviour
{
    public Action OnRayHit;
    public Action OnRayOut;

    protected GameObject _hitObj;
    protected Vector3 _hitPoint;
   
    private void FixedUpdate()
    {
        var fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        int layerMask = LayerMask.GetMask(new string[] { "RayHittable" });

        Debug.DrawLine(transform.position, transform.position + fwd * 100, Color.red);

        if (Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity, layerMask))
        {
            if (_hitObj != hit.collider.gameObject)
            {
                _hitObj = hit.collider.gameObject;
                _hitPoint = hit.point;
                RayHit();
            }
        }
        else
        {
            if (_hitObj != null)
            {
                _hitObj = null;
                _hitPoint = Vector3.zero;
                RayOut();
            }
        }
    }

    public virtual void RayHit()
    {
        OnRayHit();
    }

    public virtual void RayOut()
    {
        OnRayOut();
    }
}

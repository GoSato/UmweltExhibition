using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayIrradiatorBase : MonoBehaviour
{
    protected GameObject _hitObj;
    protected Vector3 _hitPoint;
   
    private void FixedUpdate()
    {
        var fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        int layerMask = LayerMask.GetMask(new string[] { "RayHittable" });

        Debug.DrawLine(transform.position, transform.position + fwd * 100, Color.red);
        
        if(Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity, layerMask))
        {
            _hitObj = hit.collider.gameObject;
            _hitPoint = hit.point;
        }
        else
        {
            _hitObj = null;
            _hitPoint = Vector3.zero;
        }
    }
}

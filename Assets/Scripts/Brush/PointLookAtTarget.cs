using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLookAtTarget : MonoBehaviour
{
    public Transform target;
    [HideInInspector]
    public bool isLookAtTarget = true;
    private void FixedUpdate()
    {
        if (isLookAtTarget)
        {
            transform.LookAt(target);
        }
    }
}

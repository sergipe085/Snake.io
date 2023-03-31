using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    private Transform target = null;
    private Vector3 vel = Vector3.zero;

    public void AttachTo(Transform t) {
        target = t;
    }

    private void LateUpdate() {
        if (!target) return;

        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + new Vector3(0f, 0f, -10f), ref vel, 0.2f);
    }
}

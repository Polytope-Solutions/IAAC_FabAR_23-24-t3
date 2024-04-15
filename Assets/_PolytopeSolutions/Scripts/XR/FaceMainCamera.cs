using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class FaceMainCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.up);
    }
}

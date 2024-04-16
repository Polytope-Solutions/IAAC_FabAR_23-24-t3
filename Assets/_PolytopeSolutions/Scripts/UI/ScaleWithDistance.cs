using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class ScaleWithDistance : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private float minDistance,maxDistance;
    [SerializeField] private float minScale, maxScale;
    private float minDistanceSqr, maxDistanceSqr;

    private void Start()
    {
        minDistanceSqr = minDistance*minDistance;
        maxDistanceSqr = maxDistance*maxDistance;
    }


    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - origin.position).sqrMagnitude;
        float t = Mathf.InverseLerp(minDistanceSqr, maxDistanceSqr, distance);
        t = Mathf.Clamp01(t);
        float scale = Mathf.Lerp(minScale, maxScale, t);
        transform.localScale = Vector3.one * scale;
    }
}

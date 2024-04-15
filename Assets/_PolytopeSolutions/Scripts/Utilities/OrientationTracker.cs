using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationTracker : MonoBehaviour
{
    public Transform goAnchoredPrefab;
    public Transform previewObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        previewObject.rotation = goAnchoredPrefab.rotation;
    }
}

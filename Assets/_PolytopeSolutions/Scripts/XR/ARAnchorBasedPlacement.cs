using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using TMPro;

[RequireComponent(typeof(ARAnchorManager))]
public class ARAnchorBasedPlacement : SyncObjects {
    //[SerializeField] private GameObject goAnchorPrefab;
    //
    //protected override void Start() {
    //    InisitalizeAnchors();
    //    StartCoroutine(SyncTransform());
    //}
    //public void InisitalizeAnchors() {
    //    GameObject goItem;
    //    TextMeshPro text;
    //    switch (this.mode) {
    //        case Mode.SingleAnchor:
    //            if (this.anchors != null) {
    //                foreach (GameObject item in this.anchors)
    //                    Destroy(item);
    //            }
    //            this.anchors = new GameObject[1];
    //            goItem = Instantiate(this.goAnchorPrefab, transform);
    //            goItem.transform.localPosition = Vector3.forward;
    //            goItem.transform.localRotation = Quaternion.identity;
    //            goItem.transform.localScale = Vector3.one;
    //            text = goItem.GetComponentInChildren<TextMeshPro>();
    //            text.text = "Anchor 1";
    //            break;
    //        case Mode.DualAnchor:
    //            if (this.anchors != null) { 
    //                foreach (GameObject item in this.anchors)
    //                    Destroy(item);
    //            }

    //            this.anchors = new GameObject[2];
    //            goItem = Instantiate(this.goAnchorPrefab, transform);
    //            goItem.transform.localPosition = Vector3.forward;
    //            goItem.transform.localRotation = Quaternion.identity;
    //            goItem.transform.localScale = Vector3.one;
    //            text = goItem.GetComponentInChildren<TextMeshPro>();
    //            text.text = "Anchor 1";

    //            goItem = Instantiate(this.goAnchorPrefab, goItem.transform);
    //            goItem.transform.localPosition = Vector3.right;
    //            goItem.transform.localRotation = Quaternion.identity;
    //            goItem.transform.localScale = Vector3.one;
    //            text = goItem.GetComponentInChildren<TextMeshPro>();
    //            text.text = "Anchor 2";
    //            break;
    //    }
    //}

    public void FixInSpace() {
        foreach (GameObject anchor in this.anchors) {
            anchor.AddComponent<ARAnchor>();
        }
    }
    public void UnFixInSpace() {
        foreach (GameObject anchor in this.anchors) {
            ARAnchor anchorAR = anchor.GetComponent<ARAnchor>();
            Destroy(anchorAR);
        }
    }
    
}

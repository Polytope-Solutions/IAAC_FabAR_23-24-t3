using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncObjects : MonoBehaviour {
    [SerializeField] protected GameObject goAnchoredObject;
    [SerializeField] protected bool scaleWithAnchors = true;
    [SerializeField] protected bool fixVerticalAxis;

    [SerializeField] private GameObject anchor1, anchor2;
    public enum Mode {
        SingleAnchor,
        DualAnchor
    }
    [SerializeField] protected Mode mode = Mode.SingleAnchor;
    protected GameObject[] anchors;

    protected virtual void Start() {
        this.anchors = new GameObject[2] { this.anchor1, this.anchor2 };
        StartCoroutine(SyncTransform());
    }

    protected IEnumerator SyncTransform() {
        float distance, originalDistance = (this.mode == Mode.DualAnchor) 
            ? (this.anchors[1].transform.position - this.anchors[0].transform.position).magnitude : 1;
        Vector3 temp, anchorForward;
        while (true) {
            this.goAnchoredObject.transform.position = this.anchors[0].transform.position;
            switch (this.mode) {
                case Mode.SingleAnchor:
                    if (!this.fixVerticalAxis) {
                        this.goAnchoredObject.transform.rotation = this.anchors[0].transform.rotation;
                    } else {
                        temp = this.anchors[0].transform.forward;
                        temp.y = 0;
                        this.goAnchoredObject.transform.rotation = Quaternion.LookRotation(temp.normalized, Vector3.up);
                    }
                    if (this.scaleWithAnchors)
                        this.goAnchoredObject.transform.localScale = this.anchors[0].transform.localScale;
                    break;
                case Mode.DualAnchor:
                    temp = this.anchors[1].transform.position - this.anchors[0].transform.position;
                    anchorForward = Vector3.Cross(temp, Vector3.up);

                    if (this.fixVerticalAxis) { 
                        this.goAnchoredObject.transform.rotation = Quaternion.LookRotation(anchorForward, Vector3.up);
                    }
                    else {
                        temp = Vector3.Cross(temp, anchorForward);
                        this.goAnchoredObject.transform.rotation = Quaternion.LookRotation(anchorForward, temp);
                    }
                    if (this.scaleWithAnchors) { 
                        distance = (this.anchors[1].transform.position - this.anchors[0].transform.position).magnitude;
                        this.goAnchoredObject.transform.localScale = Vector3.one * distance / originalDistance;
                    }
                    break;
            }
            yield return null;
        }
    }
}

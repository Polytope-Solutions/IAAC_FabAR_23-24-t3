using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PolytopeSolutions.Toolset.GlobalTools.Geometry {
    public class ClippingPlaneShaderSetterTransformCameraView : ClippingPlaneShaderSetter {
        [SerializeField] private bool isClipping = true;
        [SerializeField] private Transform center;
        [SerializeField] private float distance = 1;
        [SerializeField] private Camera camera;
        [SerializeField] private Slider slider;

        public float t = 0;

        protected override bool IsClipping => this.center && this.camera && this.isClipping;
        protected override Vector3 clippingPlaneNormal => -this.camera.transform.forward;
        protected override Vector3 clippingPlanePoint {
            get {
                float targetDistance = Mathf.Lerp(this.distance, -this.distance, t);
                return this.center.position + this.clippingPlaneNormal * targetDistance;
            }
        }

        private void OnEnable() {
            this.slider.onValueChanged.AddListener(SetPlane);
        }

        private void OnDisable()
        {
            this.slider.onValueChanged.RemoveListener(SetPlane);
        }

        public void SetPlane(System.Single t) {
            this.t = t;
        }

        private void OnDrawGizmos() {
            Debug.DrawLine(this.camera.transform.position, this.center.position);
            Debug.DrawLine(this.center.position, this.center.position +  clippingPlaneNormal*distance,Color.red);
            Debug.DrawLine(this.center.position, this.center.position - clippingPlaneNormal * distance, Color.green);
        }
    }
}
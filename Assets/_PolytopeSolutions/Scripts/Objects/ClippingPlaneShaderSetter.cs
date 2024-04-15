using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolytopeSolutions.Toolset.GlobalTools.Geometry {
    [ExecuteAlways]
    public abstract class ClippingPlaneShaderSetter : MonoBehaviour {
        [SerializeField] protected Material clippingShaderMaterialInstance;
        private static string propertyNameClippingPlane = "_ClippingPlane";
        private static string propertyNameIsClipping = "_Clip";
        private static string propertyNameRemapFacing = "_RemapFacing";

        protected virtual bool IsValid =>
            this.clippingShaderMaterialInstance
            && this.clippingShaderMaterialInstance.HasProperty(ClippingPlaneShaderSetter.propertyNameClippingPlane)
            && this.clippingShaderMaterialInstance.HasProperty(ClippingPlaneShaderSetter.propertyNameIsClipping)
            && this.clippingShaderMaterialInstance.HasProperty(ClippingPlaneShaderSetter.propertyNameRemapFacing);
        protected abstract bool IsClipping { get; }
        protected abstract Vector3 clippingPlaneNormal { get; }
        protected abstract Vector3 clippingPlanePoint { get; }
        private Plane clippingPlane;

        protected void OnEnable() {
            if (!this.IsValid) {
                Debug.LogError("ClippingShaderPlaneSetter: Invalid material or property name. Disabling the component.");
                this.enabled = false;
                return;
            }
        }
        protected void Update() {
            SetClippingPlaneDataToMaterial();
        }

        protected void SetClippingPlaneDataToMaterial() {
            this.clippingShaderMaterialInstance.SetFloat(ClippingPlaneShaderSetter.propertyNameIsClipping, this.IsClipping ? 1 : 0);
            #if UNITY_ANDROID && !UNITY_EDITOR
            this.clippingShaderMaterialInstance.SetFloat(ClippingPlaneShaderSetter.propertyNameRemapFacing, 0);
            #else
            this.clippingShaderMaterialInstance.SetFloat(ClippingPlaneShaderSetter.propertyNameRemapFacing, 1);
            #endif
            if (!this.IsClipping) return;
            this.clippingPlane = new Plane(this.clippingPlaneNormal, this.clippingPlanePoint);
            this.clippingShaderMaterialInstance.SetVector(ClippingPlaneShaderSetter.propertyNameClippingPlane,
                new Vector4(this.clippingPlane.normal.x, this.clippingPlane.normal.y, this.clippingPlane.normal.z, this.clippingPlane.distance));
        }
    }
}
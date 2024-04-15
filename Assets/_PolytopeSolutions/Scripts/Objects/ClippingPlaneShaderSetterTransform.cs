using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolytopeSolutions.Toolset.GlobalTools.Geometry {
    public class ClippingPlaneShaderSetterTransform : ClippingPlaneShaderSetter {
        [SerializeField] private Transform clippingPlaneTransform;
        [SerializeField] private bool isClipping = true;
        protected override bool IsClipping => this.clippingPlaneTransform && this.isClipping;
        protected override Vector3 clippingPlaneNormal => this.clippingPlaneTransform.up;
        protected override Vector3 clippingPlanePoint => this.clippingPlaneTransform.position;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PolytopeSolutions.Toolset.GlobalTools.Geometry {
    public class UI_SliderControlAnimator : MonoBehaviour{
        [SerializeField] private Animator animator;
        [SerializeField] private string floatParameterName;
        [SerializeField] private Slider slider;

        private void Start() {
            if (!this.animator)
                this.animator = GetComponent<Animator>();
            if (!this.slider)
                this.slider = GetComponent<Slider>();
            if (!this.animator || !this.slider) { 
                this.enabled = false;
                Debug.LogError("Animator or a slider wan't linked. Turning off the component.");
                return;
            }
            try { 
                this.animator.GetFloat(this.floatParameterName);
            } catch (System.Exception e) {
                Debug.LogError("failed to find the parameter. Turning off the component.");
                this.enabled = false;
            }
        }
        private void Update() {
            this.animator.SetFloat(this.floatParameterName, this.slider.value);
        }
    }
}
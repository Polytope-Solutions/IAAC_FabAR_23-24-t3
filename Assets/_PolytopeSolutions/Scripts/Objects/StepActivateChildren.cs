using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace PolytopeSolutions.Toolset.GlobalTools.Utilities {
	public class StepActivateChildren : MonoBehaviour {
		[SerializeField] private Button buttonFirst;
		[SerializeField] private Button buttonPrevious;
		[SerializeField] private Button buttonNext;
		[SerializeField] private Button buttonLast;
		[SerializeField] private bool forwardDirection = true;
        
		private int count;
		private int stage = 0;
        
		private void Awake(){
			this.count = transform.childCount;
            
			this.buttonFirst?.onClick.AddListener(() => OnFirst());
			this.buttonPrevious.onClick.AddListener(() => OnStageChanged(-1));
			this.buttonNext.onClick.AddListener(() => OnStageChanged(1));
			this.buttonLast?.onClick.AddListener(() => OnLast());
            
			UpdateChildren();
			UpdateButtonState();
		}
        
		private void OnFirst(){
			OnStageChanged(-this.count);
		}
		private void OnLast(){
			OnStageChanged(this.count);
		}
		private void OnStageChanged(int changeValue){
			int oldValue = this.stage;
			this.stage += changeValue;
			this.stage = Mathf.Clamp(this.stage, 0, this.count);
			if (oldValue != this.stage) {
				UpdateChildren();
				UpdateButtonState();
			}
		}
		private void UpdateButtonState(){
			this.buttonFirst.interactable = !(this.stage == 0);
			this.buttonPrevious.interactable = !(this.stage == 0);
			this.buttonNext.interactable = !(this.stage == this.count);
			this.buttonLast.interactable = !(this.stage == this.count);
		}
		private void UpdateChildren(){
			int index;
			for (int i = 0; i < this.count; i++) {
				index = (forwardDirection) ? i : this.count - 1 - i;
				transform.GetChild(i).gameObject.SetActive(index<=stage);
			}
		}
	}
}
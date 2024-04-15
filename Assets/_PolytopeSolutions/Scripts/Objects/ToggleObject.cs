using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolytopeSolutions.Toolset.GlobalTools.Utilities {
	public class ToggleObject : MonoBehaviour {
        
		public void Toggle(){
			gameObject.SetActive(!gameObject.activeSelf);
		}
	}
}
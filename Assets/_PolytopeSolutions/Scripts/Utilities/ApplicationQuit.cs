using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolytopeSolutions.Toolset.GlobalTools.Utilities {
    public class ApplicationQuit : MonoBehaviour {
		public void Quit() {
			#if !UNITY_EDITOR
			Application.Quit();
			#else
			UnityEditor.EditorApplication.isPlaying = false;
			#endif
		}
	}
}
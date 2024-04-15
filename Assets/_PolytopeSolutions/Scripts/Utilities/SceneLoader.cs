using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace PolytopeSolutions.Toolset.Scenes {
    public class SceneLoader : MonoBehaviour {
        [SerializeField] private string sceneName;

        public void LoadScene() {
            SceneManager.LoadScene(this.sceneName);
        }
    }
}
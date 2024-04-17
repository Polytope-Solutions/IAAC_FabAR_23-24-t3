using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadLastScene : MonoBehaviour
{
    private const string LastSceneKey = "LastScene";

    void Start()
    {
        // Check if there's a last scene saved
        if (PlayerPrefs.HasKey(LastSceneKey))
        {
            string lastSceneName = PlayerPrefs.GetString(LastSceneKey);
            SceneManager.LoadScene(lastSceneName);
        }
        else
        {
            // If there's no last scene saved, load the default scene (e.g., main menu)
            SceneManager.LoadScene("04_DesignOptions_Simran");
        }

    }

    void OnApplicationQuit()
    {
        // Save the current scene name before quitting
        PlayerPrefs.SetString(LastSceneKey, SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }
}
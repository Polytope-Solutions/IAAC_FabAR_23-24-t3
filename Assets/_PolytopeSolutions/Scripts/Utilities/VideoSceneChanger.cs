using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoSceneChanger : MonoBehaviour
{
    public VideoPlayer player;
    public string nextScene = "01_Intro_Afham";

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GetComponent<VideoPlayer>();
        }

        player.loopPointReached += EndReached;
        player.Play();
    }

    // Update is called once per frame
    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);
    }
}

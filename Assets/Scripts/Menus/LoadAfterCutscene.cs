using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadAfterCutscene : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    void Start()
    {
        _videoPlayer = GameObject.Find("Main Camera").GetComponent<VideoPlayer>();
        _videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

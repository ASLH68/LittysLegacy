using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController main;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        GetComponent<AudioSource>().Play();
    }

    private void MuteMusic()
    {
        GetComponent<AudioSource>().mute = true;
    }

    private void UnmuteMusic()
    {
        GetComponent<AudioSource>().mute = false;
    }
}

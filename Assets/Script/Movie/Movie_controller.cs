using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Movie_controller: MonoBehaviour
{
    public GameObject SkipButton;
    bool Movie_Play = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var videoPlayer = GetComponent<VideoPlayer>();
        if (Input.GetMouseButtonDown(0))
            videoPlayer.Pause();
        if (Input.GetMouseButtonDown(0))
        {
            if (Movie_Play == true)
            {
                videoPlayer.Pause();
                Movie_Play = false;
                
            }
            else{
                videoPlayer.Play();
                Movie_Play = true;
            }
        }
    }
}

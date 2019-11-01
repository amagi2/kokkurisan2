using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Movie_controller
    : MonoBehaviour
{
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

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Movie_controller: MonoBehaviour
{
    public GameObject SkipButton;//Skipボタン
    bool Movie_Play;//動画の静止判定

    //Skipボタンを押したら    
    public void OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Start()
    {
        
    }

    void Update()
    {
        var videoPlayer = GetComponent<VideoPlayer>();
        //タップを離したら
        if (Input.GetMouseButtonUp(0))
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                Movie_Play = false;
                SkipButton.gameObject.SetActive(true);
            }
            else if (!videoPlayer.isPlaying)
            {
                videoPlayer.Play();
                Movie_Play = true;
                SkipButton.gameObject.SetActive(false);
            }
        }
        /*if (videoPlayer.isPlaying)
        {
            Movie_Play = true;
        }*/
        /*if (!videoPlayer.isPlaying && Movie_Play == true)
        {
            SceneManager.LoadScene("GameScene");
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Movie_controller: MonoBehaviour
{
    public GameObject SkipButton;
    bool Movie_Play = true;
    string Tap_Object;

    /*void Tap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tap_Object = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2D)
            {
                Tap_Object = hit2D.transform.gameObject.name;
            }
        }
    }*/

    public void OnClick()
    {
        Debug.Log("押されたよ");
        SceneManager.LoadScene("GameScene");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Tap();
        var videoPlayer = GetComponent<VideoPlayer>();
        if (Input.GetMouseButtonUp(0))
        {
            if (Movie_Play == true)
            {
                videoPlayer.Pause();
                Movie_Play = false;
                SkipButton.gameObject.SetActive(true);
            }
            else if (Movie_Play == false && Tap_Object != "SkipButton") 
            {
                videoPlayer.Play();
                Movie_Play = true;
                SkipButton.gameObject.SetActive(false);
            }
        }
    }
}

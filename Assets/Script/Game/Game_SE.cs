using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_SE : MonoBehaviour
{
    public AudioClip Paper;//紙の音
    public AudioClip Life;//ライフが減る音
    public AudioClip Char;//文字が浮き出る音

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    public void Paper_SE()
    {
        audioSource.PlayOneShot(Paper);
    }
    public void Life_SE()
    {
        audioSource.PlayOneShot(Life);
    }
    public void Char_SE()
    {
        audioSource.PlayOneShot(Char);
    }
}

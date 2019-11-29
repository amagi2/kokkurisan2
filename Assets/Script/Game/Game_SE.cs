using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_SE : MonoBehaviour
{
    public AudioClip Coin;
    public AudioClip Paper;
    public AudioClip Life;
    public AudioClip Char;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Coin_SE()
    {
        audioSource.PlayOneShot(Coin);
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

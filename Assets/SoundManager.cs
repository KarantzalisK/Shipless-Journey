using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance = null;

    public AudioClip hitBird;
    public AudioClip hitBarrel;
    public AudioClip hitshark;
    public AudioClip shark;
    public AudioClip bird;


    private AudioSource soundEffectAudio;

    // Use this for initialization
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;

    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }

    //now you only have to write: SoundManager.Instance.PlayOneShot(SoundManager.Instance.thesoundofyourchoice);
}
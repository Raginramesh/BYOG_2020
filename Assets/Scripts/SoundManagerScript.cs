using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jump;
    public AudioClip collectible;
    public AudioClip die;
    public AudioClip spawn;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        audioSource.clip = jump;
        audioSource.Play();
    }

    public void PlayCollectibleSound()
    {
        audioSource.clip = collectible;
        audioSource.Play();
    }

    public void PlayDieSound()
    {
        audioSource.clip = die;
        audioSource.Play();
    }

    public void PlaySpawnSound()
    {
        audioSource.clip = spawn;
        audioSource.Play();
    }

}

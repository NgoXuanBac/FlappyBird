using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip die;
    public AudioClip hit;
    public AudioClip point;
    public AudioClip swoosh;
    public AudioClip wing;

    static AudioManager instance;

    public static AudioManager GetInstance() => instance;

    private void Awake()
    {
        AudioManager.instance = this;
    }

    public void PlayDie()
    {
        audioSource.PlayOneShot(die);
    }

    public void PlayHit()
    {
        audioSource.PlayOneShot(hit);
    }

    public void PlayPoint()
    {
        audioSource.PlayOneShot(point);
    }

    public void PlaySwoosh()
    {
        audioSource.PlayOneShot(swoosh);
    }

    public void PlayWing()
    {
        audioSource.PlayOneShot(wing);
    }
}

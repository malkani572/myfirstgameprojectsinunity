using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
  public AudioClip bgmClip;

    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = bgmClip;
        source.loop = true;
        source.playOnAwake = false;
        source.volume = 1f;
        source.Play();
        Debug.Log("Trying to play BGM...");
        AudioSource.PlayClipAtPoint(bgmClip, Vector3.zero);
    }
}

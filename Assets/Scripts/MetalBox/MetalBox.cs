using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBox : MonoBehaviour
{
    AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void BoxFall()
    {
        Invoke("PlaySound", 1);
    }

    public void PlaySound()
    {
        audioSrc.Play();
    }
}

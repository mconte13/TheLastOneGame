using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBoiling : MonoBehaviour
{
    AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSrc.Play();
        }
    }
}

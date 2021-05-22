using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    AudioSource audioSrc;
    public Vector2 ReachedPoint;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ReachedPoint = transform.position;
            audioSrc.Play();
        }
    }
}

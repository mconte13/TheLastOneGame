using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    public GameObject DirtDoor;
    public GameObject Trigger;
    AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DirtDoor.SetActive(true);
            Invoke("TriggerOff", 7);
            audioSrc.Play();
        }    
    }

    public void TriggerOff()
    {
        Trigger.SetActive(false);
    }
}

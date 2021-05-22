using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject OpenDoor;
    public GameObject CloseDoor;

    private bool canOpenTheDoor;

    AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();    
    }

    void Update()
    {
        if (canOpenTheDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canOpenTheDoor = false;
                OpenDoor.SetActive(true);
                CloseDoor.SetActive(false);
                audioSrc.Play();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canOpenTheDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canOpenTheDoor = false;
        }
    }
}

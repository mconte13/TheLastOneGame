using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    GUIControl gControl;

    private bool canTakeTheNote;

    AudioSource audioSrc;

    void Start()
    {
        gControl = GUIControl.gControl;
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canTakeTheNote)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canTakeTheNote = false;
                gControl.NoteOn();
                audioSrc.Play();
                Time.timeScale = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canTakeTheNote = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canTakeTheNote = false;
        }
    }
}

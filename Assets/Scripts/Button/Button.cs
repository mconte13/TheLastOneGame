using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject ButtonON;
    public GameObject ButtonOFF;

    public GameObject ButtonTrigger;

    private bool canPressTheButton;

    AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canPressTheButton)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canPressTheButton = false;
                ButtonON.SetActive(true);
                ButtonOFF.SetActive(false);
                ButtonTrigger.SetActive(false);
                audioSrc.Play();
                FindObjectOfType<MetalBox>().BoxFall();
            }
        }    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPressTheButton = true;
        }    
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canPressTheButton = false;
        }
    }
}

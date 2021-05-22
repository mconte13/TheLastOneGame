using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject boxTrigger;
    public GameObject key;
    public GameObject blackScreen;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            key.SetActive(false);
            boxTrigger.SetActive(false);
            FindObjectOfType<PlayerMovement>().moveSpeed = 0;
            Invoke("EndScreen", 1);
            Invoke("QuitApp", 4);
        }    
    }

    public void EndScreen()
    {
        blackScreen.SetActive(true);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}

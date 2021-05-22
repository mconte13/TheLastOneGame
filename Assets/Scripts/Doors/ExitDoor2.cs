using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ExitDoor2 : MonoBehaviour
{
    public GameObject UiObject;
    public GameObject KeyUI;
    private bool canOpenTheDoor;
    GUIControl gControl;

    void Start()
    {
        gControl = GUIControl.gControl;
        UiObject.SetActive(false);
    }

    void Update()
    {
        if (canOpenTheDoor)
        {
            if (Input.GetKeyDown(KeyCode.E) && gControl.keyOn == false)
            {
                canOpenTheDoor = false;
                UiObject.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.E) && gControl.keyOn == true)
            {
                SceneManager.LoadScene("Room3");
                KeyUI.SetActive(false);
                gControl.keyOnOff.SetActive(false);
                gControl.keyOn = false;
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
            UiObject.SetActive(false);
            canOpenTheDoor = false;
        }
    }
}

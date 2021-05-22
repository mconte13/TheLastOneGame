using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton2 : MonoBehaviour
{
    public GameObject Note2;
    public GameObject NoteWall2;

    public void CloseNote()
    {
        Note2.SetActive(false);
        NoteWall2.SetActive(false);

        Time.timeScale = 1f;
    }
}

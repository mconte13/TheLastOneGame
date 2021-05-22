using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour
{
    public GameObject Note;
    public GameObject NoteWall;

    public void Start()
    {
        NoteWall.SetActive(true);
    }

    public void CloseNote()
    {
        Note.SetActive(false);
        NoteWall.SetActive(false);

        Time.timeScale = 1f;
    }
}

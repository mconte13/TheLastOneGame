using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIControl : MonoBehaviour
{
    public static GUIControl gControl { get; private set; }
    public GameObject keyOnOff;
    public GameObject NoteOnOff;
    public bool keyOn = false;
    public bool noteOn = false;

    // Start is called before the first frame update
    private void Awake()
    {
        if(gControl == null)
        {
            gControl = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void KeyOn()
    {
        keyOnOff.SetActive(true);
        keyOn = true;
    }

    public void NoteOn()
    {
        NoteOnOff.SetActive(true);
        noteOn = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    GUIControl gControl;

    // Start is called before the first frame update
    void Start()
    {
        gControl = GUIControl.gControl;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gControl.KeyOn();
            Destroy(gameObject);
        }
    }
}

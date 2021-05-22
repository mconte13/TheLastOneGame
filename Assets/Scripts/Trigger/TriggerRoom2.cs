using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRoom2 : MonoBehaviour
{
    public GameObject HoldSphere; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            HoldSphere.SetActive(false);
        }
    }
}

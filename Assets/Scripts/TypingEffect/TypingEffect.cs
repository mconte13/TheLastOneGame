using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] phrases;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;


    void Start()
    {
        StartCoroutine(Type());    
    }

    void Update()
    {
        if(textDisplay.text == phrases[index])
        {
            continueButton.SetActive(true);
        }    
    }

    IEnumerator Type()
    {
        foreach(char letter in phrases[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextPhrase()
    {
        continueButton.SetActive(false);

        if (index < phrases.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else
        {
            continueButton.SetActive(false);
            textDisplay.text = "";
        }
    }
}

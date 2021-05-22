using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controls;

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Controls()
    {
        controls.SetActive(true);
    }

    public void Voltar()
    {
        controls.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

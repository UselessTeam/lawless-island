using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Island");
    }

    public void GoToMenu()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        transform.parent.Find("Credits").gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ShowMenu() {
        transform.parent.Find("MainMenu").gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

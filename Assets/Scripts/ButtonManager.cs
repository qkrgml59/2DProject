using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject helpUI;
    public void GameStart()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void PanelOpen()
    {
        helpUI.SetActive(true);

    }
    public void PanelDown()
    {
        helpUI.SetActive(false);
    }
}

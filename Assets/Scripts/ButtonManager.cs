using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public Canvas MainCanvas;
    public Canvas CategoryCanvas;

    void Awake()
    {
        CategoryCanvas.enabled = false;
        MainCanvas.enabled = true;
    }

    public void NewGameBtn()
    {
        MainCanvas.enabled = false;
        CategoryCanvas.enabled = true;
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

    public void OnCategory1()
    {
        MainCanvas.enabled = false;
        CategoryCanvas.enabled = false;

        GameData.SET = "Animals";
        GameData.BASE_SPRITE = "cat";
        SceneManager.LoadScene("main");
    }


}


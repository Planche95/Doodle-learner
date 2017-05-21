using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Canvas MainCanvas;
    //public Canvas LearnCanvas;
    //public Canvas CategoryCanvas;
    //public Canvas BackImageCanvas;
    //public Canvas ModeCanvas;


    //Run function before Start() method
    void Awake()
    {
        //LearnCanvas.enabled = false;
        //CategoryCanvas.enabled = false;
        //BackImageCanvas.enabled = false;
        //ModeCanvas.enabled = false;
    }

    public void Play()
    {
        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
        Application.Quit();
    }

    //public void CategoryOn()
    //{
    //    CategoryCanvas.enabled = true;
    //    MainCanvas.enabled = false;
    //}

    //public void ReturnOn()
    //{
    //    OptionsCanvas.enabled = false;
    //    MainCanvas.enabled = true;
    //}

}

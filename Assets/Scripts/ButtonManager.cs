using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void NewGameBtn()
    {
        SceneManager.LoadScene("main");
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

}


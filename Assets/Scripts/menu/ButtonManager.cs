using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Canvas[] canvases;
    private int currCanvas = 0;

    //public Canvas MainCanvas;
    //public Canvas CategoryCanvas;
    //public Canvas LevelCanvas;
    //public Canvas GameTypeCanvas;
    //public Canvas LanguageCanvas;
    //public Canvas LanSettCanvas;

    void Awake()
    {
        canvases[6].transform.GetChild(0).GetComponent<SwipeList>().enabled = false;

        canvases[0].enabled = !GameData.FROMGAME;
        canvases[1].enabled = false;
        canvases[2].enabled = GameData.FROMGAME;
        canvases[3].enabled = false;
        canvases[4].enabled = false;
        canvases[6].enabled = false;

        loadList(1, GameData.words.Keys.ToList<string>());
        loadList(3, new List<string> { "Normal Game", "Time Game" });

        if (GameData.FROMGAME)
        {
            loadList(2, Resources.LoadAll<Sprite>("Sprites/" + GameData.SET).ToList<Sprite>().Select(o => o.name).ToList());
            currCanvas = 2;
        }

        GameData.FROMGAME = true;
    }

    public void OnLearn()
    {
        canvases[6].transform.GetChild(0).GetComponent<SwipeList>().enabled = true;
        GoTo(6);
    }

    public void NewGameBtn()
    {
        GoNext();
    }

    public void OnCategory()
    {
        GameData.SET = EventSystem.current.currentSelectedGameObject.name;
        loadList(2, Resources.LoadAll<Sprite>("Sprites/" + GameData.SET).ToList<Sprite>().Select(o => o.name).ToList());
        GoNext();
    }

    public void OnLevel()
    {
        GameData.BASE_SPRITE = EventSystem.current.currentSelectedGameObject.name;
        GoNext();
    }

    public void OnType()
    {
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "Normal Game":
                GameData.GAME_TYPE = new NormalGame(5);
                break;
            case "Time Game":
                GameData.GAME_TYPE = new TimeGame();
                break;
        }
        SceneManager.LoadScene("main");
    }

    public void onLanSett()
    {
        canvases[4].enabled = true;
    }

    public void onLannguage()
    {
        GameData.CURR_LAN = (GameData.LANGUAGE)Enum.Parse(typeof(GameData.LANGUAGE), EventSystem.current.currentSelectedGameObject.name, true);
        canvases[5].transform.GetChild(0).GetChild(0).GetComponent<LanSettTextController>().changeText();
        canvases[4].enabled = false;
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

    public void setNames(Canvas canvas, List<string> names)
    {
        for (int i = 0; i < names.Count; i++)
        {
            canvas.transform.GetChild(i + 1).GetChild(0).GetComponent<Text>().text = names[i];
            canvas.transform.GetChild(i + 1).name = names[i];
        }
    }

    public void OnBack()
    {
        switch (currCanvas)
        {
            case 6:
                canvases[6].enabled = false;
                canvases[0].enabled = true;
                canvases[6].transform.GetChild(0).GetComponent<SwipeList>().reserPosition();
                canvases[6].transform.GetChild(0).GetComponent<SwipeList>().enabled = false;
                currCanvas = 0;
                break;
            default:
                canvases[currCanvas].enabled = false;
                canvases[--currCanvas].enabled = true;
                break;
        }
    }

    public void GoTo(int canvasNr)
    {
        canvases[currCanvas].enabled = false;
        canvases[canvasNr].enabled = true;
        currCanvas = canvasNr;
    }

    public void GoNext()
    {
        canvases[currCanvas].enabled = false;
        canvases[++currCanvas].enabled = true;
    }

    public void loadList(int canvasNr, List<string> names)
    {
        for (int i = 0; i < names.Count; i++)
        {
            canvases[canvasNr].transform.GetChild(i + 1).GetChild(0).GetComponent<Text>().text = names[i];
            canvases[canvasNr].transform.GetChild(i + 1).name = names[i];
        }
    }
}


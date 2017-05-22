using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Canvas MainCanvas;
    public Canvas CategoryCanvas;
    public Canvas LevelCanvas;
    public Canvas GameTypeCanvas;

    void Awake()
    {
        MainCanvas.enabled = true;
        CategoryCanvas.enabled = false;
        LevelCanvas.enabled = false;
        GameTypeCanvas.enabled = false;
    }

    public void NewGameBtn()
    {
        setNames(CategoryCanvas, GameData.words.Keys.ToList<string>());

        MainCanvas.enabled = false;
        CategoryCanvas.enabled = true;
    }

    public void OnCategory()
    {
        GameData.SET = EventSystem.current.currentSelectedGameObject.name;
        setNames(LevelCanvas, Resources.LoadAll<Sprite>("Sprites/" + GameData.SET).ToList<Sprite>().Select(o => o.name).ToList());

        CategoryCanvas.enabled = false;
        LevelCanvas.enabled = true;
    }

    public void OnLevel()
    {
        setNames(GameTypeCanvas, new List<string> { "Normal Game", "Time Game" });
        GameData.BASE_SPRITE = EventSystem.current.currentSelectedGameObject.name;

        LevelCanvas.enabled = false;
        GameTypeCanvas.enabled = true;
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
}


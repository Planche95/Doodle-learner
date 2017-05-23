using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameType
{
    public List<string> list = new List<string>();
    public List<Sprite> spritesFromList = new List<Sprite>();

    public int nrWords;
    protected int guessedCount;
    protected int wrondCount;

    protected GameObject canvas;
    protected GameObject summary;
    protected GameObject popup;
    protected GameObject word;
    protected Sprite wrong;
    protected Sprite correct;

    public GameType(int nrWords)
    {
        //canvas = GameObject.FindGameObjectWithTag("Canvas");
        popup = Resources.Load<GameObject>("Prefabs/wrongGO"); ;
        word = Resources.Load<GameObject>("Prefabs/Text (0)"); ;
        wrong = Resources.Load<Sprite>("Sprites/wrong"); ;
        correct = Resources.Load<Sprite>("Sprites/correct");

        this.nrWords = nrWords;
        guessedCount = 0;
        wrondCount = 0;

        list = new List<string>();
        spritesFromList = new List<Sprite>();
    }

    abstract public void checkInList(string name, Vector2 pos);

    abstract public List<Sprite> drawList(List<Sprite> sprites);

    public List<int> getRandomRange(int from, int to, int count)
    {
        System.Random rnd = new System.Random();
        return Enumerable.Range(from, to).OrderBy(x => rnd.Next()).Take(count).OrderBy(o => o).Reverse().ToList();
    }

    public void loadCanvas()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        summary = GameObject.FindGameObjectWithTag("Summary");
        summary.GetComponent<Canvas>().enabled = false;
    }

    public void gameOver()
    {
        float timestart = canvas.transform.GetChild(1).GetComponent<TimerController>().timeStart;

        summary.transform.GetChild(8).GetComponent<Text>().text = timestart > 0 ? 
            canvas.transform.GetChild(1).GetComponent<Text>().text : "02:00";

        GameObject.Destroy(canvas);

        summary.GetComponent<Canvas>().enabled = true;
        summary.transform.GetChild(4).GetComponent<Text>().text = wrondCount + "";
        summary.transform.GetChild(6).GetComponent<Text>().text = guessedCount + "";

        Camera.main.GetComponent<TouchController>().enabled = false;
    }
}


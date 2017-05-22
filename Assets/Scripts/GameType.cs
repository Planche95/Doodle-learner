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

    protected GameObject canvas;
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
    }
}


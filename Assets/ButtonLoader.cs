using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLoader {

    public bool isLevel;
    private Canvas canvas;

    public ButtonLoader(Canvas canvas)
    {
        this.canvas = canvas;
    }

	public void setNames () {
        List<string> names;

        if (isLevel)
        {
            names = GameData.words.Keys.ToList<string>();
        } else
        {
            names = Resources.LoadAll<Sprite>("Sprites/" + GameData.SET).ToList<Sprite>().Select(o => o.name).ToList();
        }

        for (int i = 0; i < names.Count; i++)
        {
            canvas.transform.GetChild(i + 1).GetChild(0).GetComponent<Text>().text = names[i];
        }
    }
}

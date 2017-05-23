using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LearnController : MonoBehaviour {

    public GameObject Line;
    private GameData.LANGUAGE prevLan;
    List<string> sets;

    void Start () {
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);


        prevLan = GameData.CURR_LAN;
        sets = GameData.words.Keys.ToList<string>();

        for (int j = 0; j < sets.Count; j++)
        {
            List<Sprite> sprites = Resources.LoadAll<Sprite>("Doodles/" + sets[j]).ToList<Sprite>();

            for (int i = 0; i < sprites.Count / 2; i++)
            {
                Vector3 position = Line.transform.position;
                Transform newLine = GameObject.Instantiate(Line.transform, Line.transform.position, Quaternion.identity, transform.GetChild(0).transform);
                newLine.GetComponent<RectTransform>().anchoredPosition = new Vector3(position.x, position.y - 100 * i -100 * 40 * j, position.z);
                newLine.GetChild(0).GetComponent<Image>().overrideSprite = sprites[2 * i + 1];
                newLine.GetChild(1).GetComponent<Image>().overrideSprite = sprites[2 * i];
                newLine.GetChild(2).GetComponent<Text>().text = sprites[2 * i].name;
                newLine.GetChild(3).GetComponent<Text>().text = GameData.getWordFrom(sprites[2 * i].name, sets[j]);
            }
        }
    }

    void Update()
    {
        if (!prevLan.Equals(GameData.CURR_LAN))
        {
            prevLan = GameData.CURR_LAN;

            for (int j = 0; j < sets.Count; j++)
            {
                List<Sprite> sprites = Resources.LoadAll<Sprite>("Doodles/" + sets[j]).ToList<Sprite>();

                for (int i = 0; i < sprites.Count / 2; i++)
                {
                    transform.GetChild(0).GetChild(i + 40 * j).GetChild(3).GetComponent<Text>().text = GameData.getWordFrom(sprites[2 * i].name, sets[j]);
                }
            }
        }
    }
}

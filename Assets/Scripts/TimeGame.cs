using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TimeGame : GameType
{
    private Transform newWord;

    public TimeGame() : base(40)
    {

    }

    public override void checkInList(string name, Vector2 pos)
    {
        if (list[0].Equals(name))
        {
            popup.GetComponent<SpriteRenderer>().sprite = correct;
            list.RemoveAt(0);
            randomFirst();
            newWord.GetComponent<Text>().text = GameData.getWord(list[0]);
            ++guessedCount;
        }
        else
        {
            popup.GetComponent<SpriteRenderer>().sprite = wrong;
        }

        GameObject.Instantiate(popup, new Vector3(pos.x, pos.y, 0), Quaternion.identity);

        if (guessedCount == nrWords)
        {
            //TODO END OF THE GAME
        }
    }

    public override List<Sprite> drawList(List<Sprite> sprites)
    {
        spritesFromList = sprites;
        List<string> otherSets = GameData.words.Keys.ToList<string>().Where(x => !x.Equals(GameData.SET)).ToList<string>();
        sprites = Resources.LoadAll<Sprite>("Doodles/" + otherSets[0]).ToList<Sprite>();

        list = spritesFromList.Where((x, i) => i % 2 == 0).Select(o => o.name).ToList();
        randomFirst();

        newWord = GameObject.Instantiate(word.transform, word.transform.position, Quaternion.identity, canvas.transform);
        newWord.GetComponent<RectTransform>().anchoredPosition = word.transform.position;
        newWord.GetComponent<Text>().text = GameData.getWord(list[0]);

        return sprites;
    }

    private void randomFirst()
    {
        int ran = Random.Range(0, list.Count);
        string temp = list[0];
        list[0] = list[ran];
        list[ran] = temp;
    }
}

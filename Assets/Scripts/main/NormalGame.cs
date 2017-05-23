using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NormalGame : GameType
{
    public List<string> remaing = new List<string>();

    public NormalGame(int nrWords) : base(nrWords)
    {
        
    }

    public override void checkInList(string name, Vector2 pos)
    {
        if (remaing.Contains(name))
        {
            popup.GetComponent<SpriteRenderer>().sprite = correct;

            list.Remove(name);

            canvas.transform.GetChild(remaing.IndexOf(name) + 4).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = correct;
            ++guessedCount;
        }
        else
        {
            popup.GetComponent<SpriteRenderer>().sprite = wrong;
            wrondCount++;
        }

        GameObject.Instantiate(popup, new Vector3(pos.x, pos.y, 0), Quaternion.identity);

        if (guessedCount == nrWords)
        {
            gameOver();
        }
    }

    public override List<Sprite> drawList(List<Sprite> sprites)
    {
        List<int> randList = getRandomRange(0, sprites.Count / 2 - 1, nrWords);

        foreach (int rand in randList)
        {
            spritesFromList.Add(sprites[2 * rand]);
            spritesFromList.Add(sprites[2 * rand + 1]);

            sprites.RemoveAt(2 * rand);
            sprites.RemoveAt(2 * rand);
        }

        list = spritesFromList.Where((x, i) => i % 2 == 0).Select(o => o.name).ToList();

        for (int i = 1; i <= nrWords; i++)
        {
            Vector3 position = word.transform.position;
            Transform newWord = GameObject.Instantiate(word.transform, word.transform.position, Quaternion.identity, canvas.transform);
            newWord.GetComponent<RectTransform>().anchoredPosition = new Vector3(position.x, position.y * i, position.z);
            newWord.GetComponent<Text>().text = GameData.getWord(list[i - 1]);
        }

        remaing = new List<string>(list);

        return sprites;
    }
}

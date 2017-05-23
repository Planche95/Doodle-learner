using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoardCreator: MonoBehaviour {

    public GameObject tempGameObject;
    public GameObject hintGO;

    public AudioSource normal_game_music;
    public AudioSource time_game_music;

    public List<GameObject> selectedDoodles;

    private const float DISTANCE = 0.5f;
    private const int DIVIDER = 10;
    private const float DIS_RANGE = 0.05f;
    private const float SIZE_RANGE = 0.05f;

    void Start () {

        //normal_game_music = GameObject.FindWithTag("NormalGameMusic").GetComponent<AudioSource>();
        //normal_game_music.Play();
        //Music for adequate game type
        /*if (GameData.GAME_TYPE.GetType() == typeof(NormalGame))
        {
            normal_game_music = GameObject.FindWithTag("NormalGameMusic").GetComponent<AudioSource>();
            normal_game_music.Play();
        }else if(GameData.GAME_TYPE.GetType() == typeof(TimeGame)){
            time_game_music = GameObject.FindWithTag("TimeGameMusic").GetComponent<AudioSource>();
            time_game_music.Play();
        }*/

        GameData.GAME_TYPE.loadCanvas();
        Sprite baseSprite = Resources.Load<Sprite>("Sprites/" + GameData.SET + "/" + GameData.BASE_SPRITE);
        GetComponent<SpriteRenderer>().sprite = baseSprite;
        Texture2D tex = baseSprite.texture;

        //Draw random doodles and delete them from list
        List<Sprite> setSprites = GameData.GAME_TYPE.drawList(Resources.LoadAll<Sprite>("Doodles/" + GameData.SET).ToList<Sprite>());

        //Adjust Camera and base Sprite
        Vector3 middle = new Vector3(tex.width / (2 * DIVIDER) * DISTANCE - 3, tex.height / (2 * DIVIDER) * DISTANCE, -10);
        Camera.main.transform.position = middle;
        transform.position = new Vector3(middle.x + 3, middle.y + 0.3f, 0);
        transform.localScale = new Vector3(DISTANCE * DIVIDER, DISTANCE * DIVIDER);

        //Add doodles from list
        replaceDoodles(createDoodles(setSprites, tex));

        //Music for adequate game type
        if (GameData.GAME_TYPE.GetType() == typeof(TimeGame))
        {
            time_game_music = GameObject.FindWithTag("TimeGameMusic").GetComponent<AudioSource>();
            time_game_music.Play();
        }else if(GameData.GAME_TYPE.GetType() == typeof(NormalGame)){
            normal_game_music = GameObject.FindWithTag("NormalGameMusic").GetComponent<AudioSource>();
            normal_game_music.Play();
        }
    }

    private void replaceDoodles(List<GameObject> doodles)
    {
        List<Sprite> copyList = new List<Sprite>(GameData.GAME_TYPE.spritesFromList);
        foreach (int rand in GameData.GAME_TYPE.getRandomRange(0, doodles.Count / 2 - 1, GameData.GAME_TYPE.nrWords))
        {
            int randNr = Random.Range(0, copyList.Count / 2 - 1);

            selectedDoodles.Add(doodles[rand * 2]);

            doodles[rand * 2].GetComponent<SpriteRenderer>().sprite = copyList[randNr * 2];
            doodles[rand * 2 + 1].GetComponent<SpriteRenderer>().sprite = copyList[randNr * 2 + 1];

            doodles[rand * 2].name = copyList[randNr * 2].name;
            doodles[rand * 2 + 1].name = copyList[randNr * 2 + 1].name;

            copyList.RemoveAt(randNr * 2);
            copyList.RemoveAt(randNr * 2);
        }
    }

    private List<GameObject> createDoodles(List<Sprite> setSprites, Texture2D tex)
    {
        SpriteRenderer renderer = tempGameObject.GetComponent<SpriteRenderer>();
        List<GameObject> doodles = new List<GameObject>();

        for (int x = 0, order = 0; x < tex.width / DIVIDER; x++)
        {
            for (int y = 0; y < tex.height / DIVIDER; y++)
            {
                Color pixColor = tex.GetPixel(DIVIDER * x, DIVIDER * y);

                if (pixColor.a == 1)
                {

                    Vector2 position = new Vector2(x * DISTANCE + Random.Range(-DIS_RANGE, DIS_RANGE), y * DISTANCE + Random.Range(-DIS_RANGE, DIS_RANGE));
                    Quaternion angle = Quaternion.Euler(new Vector3(0, 0, Random.Range(0.0f, 360.0f)));
                    int ran = Random.Range(0, setSprites.Count / 2);

                    renderer.sprite = setSprites[2 * ran];
                    renderer.sortingOrder = order + 1;
                    GameObject doodle = Instantiate(tempGameObject, position, angle);
                    doodle.transform.name = renderer.sprite.name;

                    renderer.sprite = setSprites[2 * ran + 1];
                    renderer.sortingOrder = order;
                    GameObject borderDoodle = Instantiate(tempGameObject, position, angle);
                    borderDoodle.transform.name = renderer.sprite.name;

                    order += 2;

                    float colDiff = (0.2126f * pixColor.r * 255 + 0.7152f * pixColor.g * 255 + 0.0722f * pixColor.b * 255) < 50f ? -0.2f : 0.2f;

                    Color borderColor = new Color(pixColor.r - colDiff, pixColor.g - colDiff, pixColor.b - colDiff);

                    if (x % 2 == 0 && y % 2 == 1 || x % 2 == 1 && y % 2 == 0)
                    {
                        pixColor.r -= 0.1f;
                        pixColor.g -= 0.1f;
                        pixColor.b -= 0.1f;
                    }

                    float offset = Random.Range(SIZE_RANGE, SIZE_RANGE);

                    doodle.GetComponent<SpriteRenderer>().color = pixColor;
                    doodle.transform.localScale += new Vector3(offset, offset, 0);

                    borderDoodle.GetComponent<SpriteRenderer>().color = borderColor;
                    borderDoodle.transform.localScale += new Vector3(offset, offset, 0);

                    doodle.AddComponent<PolygonCollider2D>();

                    doodles.Add(doodle);
                    doodles.Add(borderDoodle);
                }
            }
        }

        return doodles;
    }

    public void hint()
    {
        ShowMeAds ads = new ShowMeAds();
        ads.ShowRewardedAd();
        GameObject g = selectedDoodles.Where(x => x != null && x.GetComponent<SpriteRenderer>().sprite.name.Equals(GameData.GAME_TYPE.list[0]))
                                      .First<GameObject>();
        GameObject.Instantiate(hintGO, g.transform.position + new Vector3(Random.Range(-1.5f, 1.5f),Random.Range(-1.5f, 1.5f)), Quaternion.identity);
    }

    public void BackButton()
    {
        SceneManager.LoadScene("menu");
    }
}

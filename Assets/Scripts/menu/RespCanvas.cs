using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespCanvas : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        float buttWall = 0.4f * Screen.height;
        float spacing = (Screen.height - 2 * buttWall) / 3;
        Vector2 pos = new Vector2(0.5f * (spacing + buttWall), 0.5f * (spacing + buttWall));

        for (int i = 1; i <= 4; i++)
        {
            transform.GetChild(i).GetComponent<RectTransform>().sizeDelta = new Vector2(buttWall, buttWall);
            transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector2((i < 3 ? -1 : 1) * pos.x,
                                                                                               (i % 2 == 0 ? -1 : 1) * pos.y);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanContentController : MonoBehaviour {

	void Start () {

        float fillPercent = 0.9f;
        float backgroundHeight = Screen.height * fillPercent;
        float backgroundWidth = Screen.width * fillPercent;

        float buttWall = 0.4f;
        float buttHeight = buttWall * backgroundHeight;
        float buttWidth = buttWall * backgroundWidth;

        float spacingWidth = (backgroundWidth - 2 * buttWidth) / 3;
        float spacingHeight = (backgroundHeight - 2 * buttHeight) / 3;

        transform.parent.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        GetComponent<RectTransform>().sizeDelta = new Vector2(backgroundWidth, backgroundHeight);

        Vector2 pos = new Vector2(0.5f * (spacingWidth + buttWidth), 0.5f * (spacingHeight + buttHeight));

        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).GetComponent<RectTransform>().sizeDelta = new Vector2(buttWidth, buttHeight);
            transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector2((i < 2 ? -1 : 1) * pos.x,
                                                                                               (i % 2 == 1 ? -1 : 1) * pos.y);
        }

        string[] names = Enum.GetNames(typeof(GameData.LANGUAGE));

        for (int i = 0; i < names.Length; i++)
        {
            transform.GetChild(i).GetComponent<Button>().name = names[i];
            transform.GetChild(i).GetChild(0).GetComponent<Text>().text = names[i];
        }
	}
}

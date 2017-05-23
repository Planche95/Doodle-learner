using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanController : MonoBehaviour {

	void Start () {
        float buttWall = 0.4f * Screen.height;

        transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(buttWall, buttWall / 3);
        transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        transform.GetChild(2).GetComponent<RectTransform>().sizeDelta = new Vector2(buttWall, buttWall / 3);
        transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1.5f * buttWall / 3);

        transform.GetChild(3).GetComponent<RectTransform>().sizeDelta = new Vector2(buttWall, buttWall / 3);
        transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -3f * buttWall / 3);

        transform.GetChild(4).GetComponent<RectTransform>().sizeDelta = new Vector2(buttWall * 1.5f, buttWall * 1.5f * 388/740);
        transform.GetChild(4).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Screen.height / 4 + buttWall / 12);
    }
}

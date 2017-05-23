using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanSettController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float buttWall = 0.4f * Screen.height;

        transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(buttWall, buttWall / 3);
        transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(- buttWall / 2, buttWall / 6);

        transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(buttWall, buttWall / 3);
        transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(buttWall / 2, buttWall / 6);
    }
}

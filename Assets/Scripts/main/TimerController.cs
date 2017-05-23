using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    public float timeStart = 0f;
    private int down = 1;
	
	void Start () {
        if (GameData.GAME_TYPE.GetType().Name.Equals("TimeGame"))
        {
            timeStart = 120f;
            down = -1;
        }
	}

    void Update()
    {
        timeStart += Time.deltaTime * down;

        int min = (int)timeStart / 60;
        int sec = (int)timeStart - (min * 60);
        string sMin = min < 10 ? "0" + min : min + "";
        string sSec = sec < 10 ? "0" + sec : sec + "";

        GetComponent<Text>().text = sMin + ":" + sSec;

        if (timeStart < 0)
        {
            GameData.GAME_TYPE.gameOver();
            enabled = false;
        }
    }
}

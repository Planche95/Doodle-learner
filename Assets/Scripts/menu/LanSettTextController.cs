using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanSettTextController : MonoBehaviour
{

    private string[] shortNames = new string[] { "ENG", "PL", "DE" };

    // Use this for initialization
    void Start()
    {
        changeText();
    }

    public void changeText()
    {
        GetComponent<Text>().text = shortNames[(int)GameData.CURR_LAN];
    }
}

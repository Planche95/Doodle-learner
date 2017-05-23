using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummCanController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Canvas>().enabled = false;
        transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = false;
	}
}

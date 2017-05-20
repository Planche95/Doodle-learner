using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroudController : MonoBehaviour {

	void Start () {
        transform.position = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2)).y, transform.position.z);
        Image image = GetComponent<Image>();
        image.rectTransform.sizeDelta = new Vector2(image.rectTransform.sizeDelta.x, Screen.height);
    }
}

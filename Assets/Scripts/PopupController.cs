using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour {

    public float speed = 2f;

    private float opacity;
    private Color col;
	
	void Start () {
        opacity = 1;
        col = GetComponent<SpriteRenderer>().material.color;
    }

    void Update()
    {
        col.a = opacity;
        GetComponent<SpriteRenderer>().material.color = col;
        opacity -= speed * Time.deltaTime;

        if(opacity <= 0)
        {
            Destroy(gameObject);
        }
    }
}

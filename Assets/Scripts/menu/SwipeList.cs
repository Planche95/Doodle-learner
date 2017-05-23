using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeList : MonoBehaviour {

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.GetChild(0).position;
    }

	void Update () {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            transform.GetChild(0).Translate(0, touchDeltaPosition.y * 0.1f, 0);

            if (transform.GetChild(0).position.y <= startPos.y)
            {
                transform.GetChild(0).position = startPos;
            }
        }
    }

    public void reserPosition()
    {
        transform.GetChild(0).position = startPos;
    }
}

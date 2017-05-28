using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyTexture : MonoBehaviour {

    public RenderTexture backGround;
    private bool ehe = true;
	// Use this for initialization
	void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log(backGround.IsCreated());

        if (backGround.IsCreated() && ehe)
        {
            Debug.Log(backGround.IsCreated());

            Texture2D texture = new Texture2D(backGround.width, backGround.height);

            RenderTexture.active = backGround;
            texture.ReadPixels(new Rect(0, 0, backGround.width, backGround.height), 0, 0);
            texture.Apply();

            GetComponent<RawImage>().texture = texture;

            ehe = false;
            this.GetComponent<CopyTexture>().enabled = false;
            this.GetComponent<RawImage>().enabled = true;

            BoardCreator.turnOffSprites();

            enabled = false;
            gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("texCam").SetActive(false);
        }
    }

    public void test()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}

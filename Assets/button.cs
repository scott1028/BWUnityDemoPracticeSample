using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
    Texture[] buttonImages = new Texture[4];

	// Use this for initialization
	void Start () {
        // 取得材質
        this.buttonImages[0] = Resources.Load<Texture>("Textures/btn_start_click");     // start
        this.buttonImages[1] = Resources.Load<Texture>("Textures/btn_start_enter");     // start hover
        this.buttonImages[2] = Resources.Load<Texture>("Textures/btn_stop_normal");     // stop
        this.buttonImages[3] = Resources.Load<Texture>("Textures/btn_stop_enter");      // stop hover
	}
	
	// Update is called once per frame
	void Update () {
        bool buttonClick=Input.GetMouseButtonDown(0);

        if (buttonClick) {
            main.gameOnOrOff = !main.gameOnOrOff;
        }
	}

    void OnMouseOver()
    {
        this.turnButton(1);
    }

    void OnMouseExit()
    {
        this.turnButton(0);
    }

    // 控制材質切換
    void turnButton(int flag) {
        if (main.gameOnOrOff)
        {
            this.gameObject.GetComponent<GUITexture>().texture = this.buttonImages[flag + 2];
            main.gameOnOrOff = true;
        }
        else
        {
            this.gameObject.GetComponent<GUITexture>().texture = this.buttonImages[flag + 0];
            main.gameOnOrOff = false;
        }
    }
}

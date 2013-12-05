using UnityEngine;
using System.Collections;

public class btn_start_click_script : MonoBehaviour {

    Texture[] buttonImages=new Texture[4];  //應該是四張圖分成兩組 0~1, 2~3
    int imageIndexOffset = 0;   // 圖像的切換索引偏移值
    bool ifClickButton;
    GameObject mainObject;

    void init()
    {
        this.buttonImages[0] = Resources.Load<Texture>("Textures/btn_start_click");
        this.buttonImages[1] = Resources.Load<Texture>("Textures/btn_start_enter");
        this.buttonImages[2] = Resources.Load<Texture>("Textures/btn_stop_normal");
        this.buttonImages[3] = Resources.Load<Texture>("Textures/btn_stop_enter");
    }

    void getMainObject() {
        mainObject = Camera.main.gameObject;
    }

	// Use this for initialization
	void Start () {
        this.init();
	}
	
	// Update is called once per frame
	void Update () {
        ifClickButton = Input.GetMouseButtonUp(0);

        // toPlay
        if (ifClickButton == true && this.imageIndexOffset == 0 && this.guiTexture.HitTest(Input.mousePosition))
        {
            this.imageIndexOffset = 2;

            if (!mainObject) { this.getMainObject(); }
            
            if (mainObject) {
                mainObject.gameObject.BroadcastMessage("setMainObj", true);
            }
        }
        // toStop
        else if (ifClickButton == true && this.imageIndexOffset == 2 && this.guiTexture.HitTest(Input.mousePosition)) {
            this.imageIndexOffset = 0;

            if (!mainObject) { this.getMainObject(); }

            if (mainObject)
            {
                mainObject.gameObject.BroadcastMessage("setMainObj", false);
            }
        }
	}

    void OnMouseOver()
    {
        this.gameObject.GetComponent<GUITexture>().texture = this.buttonImages[1 + this.imageIndexOffset];
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<GUITexture>().texture = this.buttonImages[0 + this.imageIndexOffset];
    }
}

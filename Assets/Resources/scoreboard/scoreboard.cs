using UnityEngine;
using System.Collections;
using System;

public class scoreboard : MonoBehaviour
{

    public int score;
    float margin = 0.35f;
    GameObject scoreNumber;
    GameObject num;

	// Use this for initialization
	void Start () {
        scoreNumber = Resources.Load<GameObject>("scoreboard/number");
        setScore(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (main.gameOnOrOff)
        {
            this.score+=1;
            setScore(this.score);
        }
	}

    // 設定分數的副程式
    void setScore(int score) {
        this.clearNumber();
        this.score = score;
        char[] chr = this.score.ToString().ToCharArray();
        for (int i = chr.Length-1; i >=0 ; i--)
        {
            num = Instantiate(this.scoreNumber) as GameObject;
            num.transform.parent = this.gameObject.transform;
            num.transform.Find("number").renderer.material.mainTextureOffset = new Vector2((Convert.ToInt32(chr[i]) - 48) * 0.1f, 0);
            num.transform.localPosition = new Vector3(i * margin, 0, 0);
        }
    }

    // 清除數字的副程式
    void clearNumber() {
        int childCount = this.gameObject.transform.childCount;
        for (int i = 0; i < childCount; i++) {
            if(this.gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
                Destroy(this.gameObject.transform.GetChild(i).gameObject);
        }
    }
}

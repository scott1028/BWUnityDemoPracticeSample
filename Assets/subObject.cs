using UnityEngine;
using System.Collections;

public class subObject : MonoBehaviour {
    float materialOffset = 0f;
    float step = 0f;
    float materialChangeSpeed = 4f;
    int currentTextureStep = 0;
    int lastTextureStep=-1;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

    void FixedUpdate() {
        if (main.gameOnOrOff)
        {
            // 自轉
            this.gameObject.transform.Rotate(0, Time.deltaTime * this.materialChangeSpeed * 50, 0);

            // 計算材質切換時機
            this.step += Time.deltaTime;
            this.currentTextureStep = Mathf.RoundToInt(this.step * 100 * 2 * this.materialChangeSpeed) / 100;
            if (this.currentTextureStep > this.lastTextureStep)
            {
                this.materialChange();
                this.lastTextureStep = this.currentTextureStep;
            }
        }
    }

    // 撞到另一個球觸發換立足點
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.transform.parent = other.gameObject.transform;
    }

    // 切換材質副程式
    void materialChange() {
        this.materialOffset += 0.16667f;
        this.gameObject.renderer.material.mainTextureOffset = new Vector2(0, this.materialOffset);
        if (this.materialOffset >= 1 - 0.16667f) { this.materialOffset = 0; }
    }
}

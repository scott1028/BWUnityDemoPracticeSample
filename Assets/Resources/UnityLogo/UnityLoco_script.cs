using UnityEngine;
using System.Collections;

public class UnityLoco_script : MonoBehaviour {

    float x0 = 800;
    float x1 = 245;

    bool coroutinCalled = false;
    bool canLeft = true;
    bool canRight = false;

    Rect guiSet;

	// Use this for initialization
	void Start () {
        this.guiSet=this.gameObject.guiTexture.pixelInset;
	}
	
	// Update is called once per frame
	void Update () {
        // 往右移動
        if (this.gameObject.guiTexture.pixelInset.x <= this.x1 && this.coroutinCalled == false)
        {
            this.canLeft = false;
            this.coroutinCalled = true;
            StartCoroutine(setTimeout());
        }
        // 往左移動
        else if (this.gameObject.guiTexture.pixelInset.x <= this.x0 && this.canLeft == true)
        {
            this.guiSet.x -= Time.deltaTime * 200;
            this.gameObject.guiTexture.pixelInset = this.guiSet;
        }
        else if (this.canRight == true && this.gameObject.guiTexture.pixelInset.x <= this.x0)
        {
            this.guiSet.x += Time.deltaTime * 200;
            this.gameObject.guiTexture.pixelInset = this.guiSet;
        }
	}

    IEnumerator setTimeout() {
        yield return new WaitForSeconds(3);
        this.canRight = true;
        yield break;
    }
}

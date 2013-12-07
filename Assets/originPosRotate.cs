using UnityEngine;
using System.Collections;

public class originPosRotate : MonoBehaviour {

    // 方向請用 Unity Control Panel 設定
    public int directionFlag;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (main.gameOnOrOff)
        {
            this.gameObject.transform.Rotate(0, 0, Time.deltaTime * 50 * this.directionFlag);
        }
	}
}

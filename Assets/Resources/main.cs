using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

    GameObject prefabPlane;
    GameObject mainObj;
    GameObject originA;
    //public bool ifPlayButtonOn = false;
    public float autoScore;
    GameObject scoreboardPrefab;
    GameObject scoreboard;
    GameObject mainObject;

	// Use this for initialization
	void Start () {
        this.autoScore = 0f;
        this.originA = GameObject.FindGameObjectWithTag("originA");
        //this.originB = GameObject.FindGameObjectWithTag("originB");
        prefabPlane = Resources.Load<GameObject>("mainObject/Plane");
        mainObj = Instantiate(prefabPlane) as GameObject;
        mainObj.transform.parent = this.originA.transform;
        mainObj.transform.localPosition = new Vector3(0, 2, 0);
        this.scoreboardPrefab = Resources.Load<GameObject>("scoreboard/scoreboard");
        this.scoreboard = Instantiate(scoreboardPrefab) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

        mainObject = GameObject.FindGameObjectWithTag("mainObject");

        if (mainObject.GetComponent<mainObject_script>().ifPlayButtonOn == true)
        {
            this.autoScore += Time.deltaTime * 25;
            this.scoreboard.BroadcastMessage("setScore", Mathf.FloorToInt(this.autoScore));
        }
	}

    void setMainObj(bool flag) {
        mainObj.GetComponent<mainObject_script>().ifPlayButtonOn = flag;
    }
}

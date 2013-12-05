using UnityEngine;
using System.Collections;

public class mainObject_script : MonoBehaviour
{
    // A to B is 3 len.
    GameObject originA;
    GameObject originB;
    float lenghtFromOriginAToOriginB;
    float lenghtFromObjToOriginB;
    float lenghtFromObjToOriginA;
    Vector3 nextPos;
    float changePathWhenDistanceIs;
    bool canChangeToPathB;
    bool canChangeToPathA;
    int directionFlagAndSpeedWeight;
    public bool ifPlayButtonOn = false;
    float materialOffset = 0f;
    bool ifAnimationIsPlaying = false;

    void init()
    {
        this.changePathWhenDistanceIs = 1.5f;
        this.originA = GameObject.FindGameObjectWithTag("originA");
        this.originB = GameObject.FindGameObjectWithTag("originB");
        this.originA.renderer.enabled = false;
        this.originB.renderer.enabled = false;
        this.lenghtFromOriginAToOriginB = Vector3.Distance(originA.transform.position, originB.transform.position);
        this.canChangeToPathB = true;
        this.canChangeToPathA = false;
        this.directionFlagAndSpeedWeight=2;
    }

	// Use this for initialization
	void Start () {
        this.init();
	}
	
	// Update is called once per frame
	void Update () {
        if (ifPlayButtonOn==true)
        {
            this.doObjGoing(this.gameObject);
            this.doChangePath(this.gameObject);
        }

        // 偵測是否需要開始撥放動畫
        if (ifPlayButtonOn == true && this.ifAnimationIsPlaying==false)
        {
            StartCoroutine(changeMaterialProcessor());
        }
	}

    // 動畫切圖部分
    IEnumerator changeMaterialProcessor() {
        while (ifPlayButtonOn)
        {
            this.ifAnimationIsPlaying = true;
            yield return new WaitForSeconds(0.1f);
            this.changeMaterial();
            //Debug.Log(this.ifAnimationIsPlaying);
        }
        this.ifAnimationIsPlaying = false;
        yield break;
    }

    // 切換材質球 Offset
    void changeMaterial() {
        //Debug.Log(this.materialOffset);
        this.materialOffset+=0.16667f;
        this.gameObject.transform.Find("Plane").renderer.material.mainTextureOffset = new Vector2(0, this.materialOffset);
        if (this.materialOffset >= 1 - 0.16667f) { this.materialOffset = 0; }
    }

    // 讓物件移動
    void doObjGoing(GameObject x) {
        // 計算與originA點的距離
        this.lenghtFromObjToOriginA = Mathf.Round(Vector3.Distance(x.transform.position, this.originA.transform.position)*10)/10;
        // 計算與originB點的距離
        this.lenghtFromObjToOriginB = Mathf.Round(Vector3.Distance(x.transform.position, this.originB.transform.position)*10)/10;

        this.nextPos = RotateAroundPoint(x.transform.localPosition, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, -10f * this.directionFlagAndSpeedWeight * Time.deltaTime * 3));
        x.transform.Rotate(new Vector3(0f, 0f, -20f * this.directionFlagAndSpeedWeight * Time.deltaTime * 3));
        x.transform.localPosition = this.nextPos;
    }

    // 偵測是否要改變路線
    void doChangePath(GameObject x)
    {
        // 當接近B一定距離的時候換軌道, 換完軌道後關閉可以換到軌道B的 Flag
        if (this.lenghtFromObjToOriginB == 1.5 && this.canChangeToPathB == true)
        {
            this.canChangeToPathB = false;
            x.transform.parent = this.originB.transform;
            this.directionFlagAndSpeedWeight *= -1;
        }
        // 當離A點超越距離2的時候開啟換回軌道A的Flag
        else if (this.lenghtFromObjToOriginA > 2)
        {
            this.canChangeToPathA = true;
        }
        // 當接近A一定距離的時候換軌道, 換完軌道後關閉可以換到軌道A的 Flag
        else if (this.lenghtFromObjToOriginA == 2 && this.canChangeToPathA == true)
        {

            this.canChangeToPathA = false;
            x.transform.parent = this.originA.transform;
            this.directionFlagAndSpeedWeight *= -1;
        }
        // 當離B點大於1.5的時候開啟換回軌道B的Flag
        else if (this.lenghtFromObjToOriginB > 1.5)
        {
            this.canChangeToPathB = true;
        }
    }

    // 繞著圓點旋轉(點,原點,角度)
    Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot,Quaternion angle) {
        return angle * ( point - pivot) + pivot;
    }
}

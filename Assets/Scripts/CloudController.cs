using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

    private float minimum = 1.0f; //最小値
    private float magSpeed = 10.0f;//timeを10倍する
    private float magnification = 0.07f; //倍率

    void Start () {
		
	}
	
	void Update () {
        //localScaleで元のサイズを基準にX･Z方向に拡縮させる
        //拡縮の倍率は、1 ± 0.07 * (-1~1)
        this.transform.localScale = new Vector3(this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);

    }
}
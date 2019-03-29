using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*発展課題用*/

//ほぼレッスンで書いたスクリプトを流用
//キー入力で動く部分を、画面の左右を押しているかのフラグに置き換えて対応

public class TouchFripperController : MonoBehaviour
{
    //左右タッチ判定用のTouchDetectorをアタッチしてフラグを参照する
    public GameObject gameobject;

    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }
    
    void Update()
    {

        //フラグの状態を取得する
        bool rightTouch = gameobject.GetComponent<TouchDetector>().rightFlag;
        bool leftTouch = gameobject.GetComponent<TouchDetector>().leftFlag;

        //左フラグがオンの時(画面左をタッチされている時)左フリッパーを動かす
        if ((leftTouch==true) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //画面右をタッチされている時、右フリッパーを動かす
        if ((rightTouch==true) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //フラグがオフの時(タッチが離された時)フリッパーを元に戻す
        if ((leftTouch == false) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if ((rightTouch==false) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
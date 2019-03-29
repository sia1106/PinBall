using UnityEngine;
using System.Collections;

/*発展課題用*/

//画面の左右どちらにタッチされているかを判別するスクリプト
public class TouchDetector : MonoBehaviour
{
    //判定用のフラグ、TouchFlipperControllerに参照させる為publicにしてある
    public bool rightFlag = false;
    public bool leftFlag = false;

    //タッチされている間のみフラグをオンにする
    void Update()
    { 
        
        //タッチされた        
        if (Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
            //押した順にタッチ情報が格納される配列
            Touch[] myTouches = Input.touches;

            for (int i = 0; i < Input.touchCount; i++)
            {
                //各タッチ情報のスクリーン座標をワールド座標に変換し、X座標の正負を取得
                Vector3 screenPos = myTouches[i].position;
                screenPos.z = 1.0f; //Z座標が無いと正しく変換できないらしいので設定
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                float LeftorRight = Mathf.Sign(worldPos.x);

                //正負で左右を判別、厳密に0だった場合は右側に含める
                if (LeftorRight >= 0)   //タッチのX座標が正または0(右側)
                {
                    if (myTouches[i].phase == TouchPhase.Began)
                    {
                        rightFlag = true;
                    }
                    if (myTouches[i].phase == TouchPhase.Ended)
                    {
                        rightFlag = false;
                    }
                }
                else if(LeftorRight < 0)  //左側
                {
                    if (myTouches[i].phase == TouchPhase.Began)
                    {
                        leftFlag = true;
                    }
                    if (myTouches[i].phase == TouchPhase.Ended)
                    {
                        leftFlag = false;
                    }
                }
                
            }
        }
    }

}
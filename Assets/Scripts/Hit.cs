using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
課題：UIのTextを使って得点を表示してください
ターゲット（大小の星と雲）にボールが衝突した時に得点を加算してください
ターゲットの種類によって取得できる点数を変えてください（例：小さい星は10点、大きい星は20点など）
得点は(ゲームビューの画面サイズを変えても常に) 画面の右上に見やすく表示するようにしましょう
*/

//ballにアタッチされ特定タグとの衝突によりscoreに点数が加算
//updateでスコアパネルに反映

public class Hit : MonoBehaviour {

    private GameObject scoreText;
    private int score = 0;

    void Start()
    {
        //パネルを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    //ballがオブジェクトに接触した際に呼び出され、タグによってscoreに点数加算
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SmallStarTag"))
        {
            score += 5;
        }
        else if (other.gameObject.CompareTag("LargeStarTag"))
        {
            score += 20;
        }
        else if (other.gameObject.CompareTag("SmallCloudTag"))
        {
            score += 50;
        }
        else if (other.gameObject.CompareTag("LargeCloudTag"))
        {
            score += 100;
        }
        else { }
    }

    // 毎フレーム点数を取得して更新
    void Update()
    {
        this.scoreText.GetComponent<Text>().text = score + "pt";
    }

}
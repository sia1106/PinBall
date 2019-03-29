using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;
    
    private GameObject gameoverText;
    
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }
    
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            //1秒後にリトライ
            Invoke("Retry", 1);
            
        }
    }
    void Retry()
    {
        //リトライ用
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}


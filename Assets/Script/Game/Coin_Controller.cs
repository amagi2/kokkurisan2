using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Controller : MonoBehaviour
{
    private Vector3 Mouse_Pos;//マウスの座標
    private Vector3 WorldPointPos;//画面を起点とした世界座標
    public string Tap_Char;//選択した文字をゲームコントローラーに送る

    //コイン移動
    public void Move_Coin()
    {
        //マウスの座標を確認
        Mouse_Pos = Input.mousePosition;
        WorldPointPos = Camera.main.ScreenToWorldPoint(Mouse_Pos);

        //Z軸は固定
        WorldPointPos.z = 0;

        //コインをマウスの座標に確認
        gameObject.transform.position = WorldPointPos;
    }

    //コインを定位置に戻す
    public void Return_Coin()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    //重なってる間は名前を取得
    private void OnCollisionStay2D(Collision2D collision)
    {
        Tap_Char = collision.gameObject.name;
    }

    //離れたら空にする
    private void OnCollisionExit2D(Collision2D collision)
    {
        Null();
    }

    //Tap_Charを空にする
    public void Null()
    {
        Tap_Char = null;
    }

    //初期設定
    void Start()
    {
        Null();
    }

    void Update()
    {

    }
}

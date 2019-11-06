using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public GameObject Coin;//Coin_Controller
    public GameObject Paper;//文字盤
    string Tap_Object;//タップ先のオブジェクト
    string Get_Char;//Coin_Controllerから受け取る

    [SerializeField]
    private GameObject[] Life = new GameObject[3];//LifeのUI
    int life;//残りLife


    //タップ座標の取得
    void Tap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //空にする
            Tap_Object = null;

            //レイを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            //レイが当たったらゲームオブジェクトの名前を取得
            if (hit2D)
            {
                Tap_Object = hit2D.transform.gameObject.name;
            }
        }
    }
    

    //タップ関連
    void Tap_Command()
    {
        //タップしたとき
        if (Input.GetMouseButton(0))
        {
            //コインだったら紙を出してコインを動かす
            if (Tap_Object == "Coin")
            {
                Paper.gameObject.SetActive(true);
                Coin.GetComponent<Coin_Controller>().Move_Coin();
            }
            //虫だったら
            //なんかだったらetc
        }
        //離したら
        if (Input.GetMouseButtonUp(0))
        {
            //紙を隠してコインを戻す
            Paper.gameObject.SetActive(false);
            Coin.GetComponent<Coin_Controller>().Return_Coin();

            //コインと重なってたObjectを確認して合否判定
            Get_Char = Coin.GetComponent<Coin_Controller>().Tap_Char;

            //合ってたら
            if (Get_Char == "答え") 
            {
                //何かしらの処理
                Debug.Log("正解");//仮
            }
            //違ったら
            if (Get_Char != null && Get_Char != "答え") 
            {
                //ライフ減らす
                life -= 1;
                Life[life].gameObject.SetActive(false);

                //ライフがなくなったら
                if (life == 0)
                {
                    //何かしらの処理
                    Debug.Log("あ；おえんｈｃｓｒぎうｍんｓｃｌｓｆんｋｇｃんｓｌｍｇんｂｓｎ");//仮
                }
            }
            Coin.GetComponent<Coin_Controller>().Null();
        }
    }

    //初期設定
    void Start()
    {
        life = 3;
    }

    void Update()
    {
        Tap();
        Tap_Command();
    }
}

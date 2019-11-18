using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    public GameObject Coin;//Coin_Controller
    public GameObject Paper;//文字盤
    string Tap_Object;//タップ先のオブジェクト
    string Get_Char;//Coin_Controllerから受け取る

    string[] Answer ={
        "A","I","U","E","O",
        "KA","KI","KU","KE","KO",
        "SA","SI","SU","SE","SO",
        "TA","TI","TU","TE","TO",
        "NA","NI","NU","NE","NO",
        "HA","HI","HU","HE","HO",
        "MA","MI","MU","ME","MO",
        "YA","YU","YO",
        "RA","RI","RU","RE","RO",
        "WA","WO","N"
    };//答え
    int i;



    [SerializeField]
    private GameObject[] Life = new GameObject[3];//LifeのUI
    int life;//残りLife

    void Answer_Set()
    {

        i = Random.Range(0, 45);
        Debug.Log(i);
    }


    //タップ座標の取得
    void Tap()
    {
        //タップを認識
        if (Input.touchCount > 0)//タッチ数が１以上の時
        {
            //タップした座標を確認
            Touch t = Input.GetTouch(0);
            Vector3 touchPint_screen = new Vector3(t.position.x, t.position.y, 0);
            Vector3 touchPint_world = Camera.main.ScreenToWorldPoint(touchPint_screen);
            Collider2D tap = Physics2D.OverlapPoint(touchPint_world);

            //画面に触れたとき
            if (Input.GetMouseButtonDown(0))
            {
                //タップしたものの名前を取得
                Tap_Object = tap.gameObject.name;
            }

            //コインだったら
            if (Tap_Object == "Coin")
            {
                //
                Paper.gameObject.SetActive(true);
                Coin.GetComponent<Coin_Controller>().Move_Coin();
            }
            //Gだったら

            //なんかだったら

            if (Input.GetMouseButtonUp(0))
            {
                Paper.gameObject.SetActive(false);
                Coin.GetComponent<Coin_Controller>().Return_Coin();
                //コインと重なってたObjectを確認する
                Get_Char = Coin.GetComponent<Coin_Controller>().Tap_Char;
                Debug.Log(Get_Char);
                Tap_Object = null;
            }
            

            //合ってたら
            if (Get_Char == Answer[i])
            {
                //何かしらの処理
                Debug.Log("正解");//仮
                Get_Char = null;
            }
            //違ったら
            if (Get_Char != null && Get_Char != Answer[i])
            {
                //ライフ減らす
                life -= 1;
                Life[life].gameObject.SetActive(false);
                Get_Char = null;
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
        Answer_Set();
    }

    void Update()
    {
        Tap();
    }

}

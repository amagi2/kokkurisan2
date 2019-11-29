using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public GameObject Coin;//Coin_Controller
    public GameObject Paper;//文字盤
    public GameObject Game_SE;//SE

    private string Tap_Object;//タップ先のオブジェクト
    private string Get_Char;//Coin_Controllerから受け取る

    [SerializeField]
    private GameObject[] Question = new GameObject[18];//問題（オブジェクト）
    [SerializeField]
    private GameObject[] Char = new GameObject[18];//答え（表示）

    private int Q_Num;//問題（設定）

    //答え（選択）
    private string[] Answer ={
        /*0*/"A","I","U","E","O",
        /*5*/"KA","KI","KU","KE","KO",
        /*10*/"SA","SI","SU","SE","SO",
        /*15*/"TA","TI","TU","TE","TO",
        /*20*/"NA","NI","NU","NE","NO",
        /*25*/"HA","HI","HU","HE","HO",
        /*30*/"MA","MI","MU","ME","MO",
        /*35*/"YA","YU","YO",
        /*38*/"RA","RI","RU","RE","RO",
        /*43*/"WA","WO","N"
    };
    private int[] A_Num ={
        /*SU*/12,
        /*I*/1,
        /*YU*/36
    };
    /*private bool[] Answer_Count =
    {
        false,false,true
    };*/

    [SerializeField]
    private GameObject[] Life = new GameObject[3];//LifeのUI
    private int life;//残りLife

    public static int Scene_Count = 1;//シーン何回目か

    bool G_SE = true;

    //問題設定
    void Answer_Set()
    {
        //何シーンか確認
        //シーンに合った問題をランダムで選ぶ
        switch (Scene_Count)
        {
            case 1:
                Q_Num = Random.Range(0, 3);
                break;
            case 2:
                Q_Num = Random.Range(0, 3) + 3;
                break;
            case 3:
                Q_Num = Random.Range(0, 3) + 6;
                break;
            case 4:
                Q_Num = Random.Range(0, 3) + 9;
                break;
            case 5:
                Q_Num = Random.Range(0, 3) + 12;
                break;
            case 6:
                Q_Num = Random.Range(0, 3) + 15;
                break;
        }
        //選んだ問題を表示する
        Question[Q_Num].gameObject.SetActive(true);
    }
    


    //タップ
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
                if (G_SE)
                {
                    Game_SE.GetComponent<Game_SE>().Coin_SE();
                    Game_SE.GetComponent<Game_SE>().Paper_SE();
                    G_SE = false;
                }
                Paper.gameObject.SetActive(true);
                Coin.GetComponent<Coin_Controller>().Move_Coin();
            }
            //Gだったら

            //なんかだったら

            //画面から離したとき
            if (Input.GetMouseButtonUp(0))
            {
                Paper.gameObject.SetActive(false);
                Coin.GetComponent<Coin_Controller>().Return_Coin();

                //コインと重なってたObjectを確認する
                Get_Char = Coin.GetComponent<Coin_Controller>().Tap_Char;
                
                Tap_Object = null;
                G_SE = true;


                //合ってたら
                if (Get_Char == Answer[A_Num[Q_Num]])
                {
                    //SE
                    Game_SE.GetComponent<Game_SE>().Char_SE();

                    //文字の表示
                    Char[Q_Num].gameObject.SetActive(true);
                    Char[Q_Num].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                    Get_Char = null;
                    //
                    SceneManager.LoadScene("MovieScene");
                }
                //違ったら
                else if (Get_Char != null && Get_Char != Answer[A_Num[Q_Num]])
                {
                    //SE
                    Game_SE.GetComponent<Game_SE>().Life_SE();

                    //ライフ減らす
                    life -= 1;
                    Life[life].gameObject.SetActive(false);
                    Get_Char = null;

                    //ライフがなくなったら
                    if (life == 0)
                    {
                        //何かしらの処理
                        SceneManager.LoadScene("GameOverScene");
                    }
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

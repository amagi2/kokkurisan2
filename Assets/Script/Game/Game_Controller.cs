using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public GameObject Coin;     //Coin_Controller
    public GameObject Paper;    //文字盤
    public GameObject Game_SE;  //SE
    public GameObject G;        //G

    private string Tap_Object;  //タップ先のオブジェクト
    private string Get_Char;    //Coin_Controllerから受け取る

    [SerializeField]
    private GameObject[] Question = new GameObject[18]; //問題（オブジェクト）
    [SerializeField]
    private GameObject[] Char = new GameObject[18];     //答え（表示）

    private int Q_Num;//問題（設定）

    //答え（選択）
    private string[] Answer ={
        /*0*/"A","I","U","E","O",       /*4*/
        /*5*/"KA","KI","KU","KE","KO",  /*9*/
        /*10*/"SA","SI","SU","SE","SO", /*14*/
        /*15*/"TA","TI","TU","TE","TO", /*19*/
        /*20*/"NA","NI","NU","NE","NO", /*24*/
        /*25*/"HA","HI","HU","HE","HO", /*29*/
        /*30*/"MA","MI","MU","ME","MO", /*34*/
        /*35*/"YA","YU","YO",           /*37*/
        /*38*/"RA","RI","RU","RE","RO", /*42*/
        /*43*/"WA","WO","N"             /*45*/
    };
    //答え（設定）
    private int[] A_Num ={
        /*SU*/12,
        /*I*/1,
        /*YU*/36
    };

    SpriteRenderer spriteRenderer;
    float Add_a = 0.05f;
    float a;
    float CoolTime;
    float SetTime;

    /*private bool[] Answer_Count =
    {
        false,false,true
    };*/

    [SerializeField]
    private GameObject[] Life = new GameObject[3];  //LifeのUI
    private int life;                               //残りLife

    public static int Scene_Count;//シーン何回目か

    bool G_SE = true;

    //問題設定
    void Answer_Set()
    {
        //何シーンか確認、シーンに合った問題をランダムで選ぶ
        switch (Scene_Count)
        {
            case 1:
                Q_Num = Random.Range(0, 3);
                break;
            case 2:
                Q_Num = Random.Range(3, 6);
                break;
            case 3:
                Q_Num = Random.Range(6, 9);
                break;
            case 4:
                Q_Num = Random.Range(9, 12);
                break;
            case 5:
                Q_Num = Random.Range(12, 15);
                break;
            case 6:
                Q_Num = Random.Range(15, 18);
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
                //SE
                if (G_SE)
                {
                    Game_SE.GetComponent<Game_SE>().Paper_SE();
                    G_SE = false;
                }
                //文字盤表示してコインを動かす
                Paper.gameObject.SetActive(true);
                Coin.GetComponent<Coin_Controller>().Move_Coin();
            }
            //Gだったら
            if (Tap_Object == "G")
            {
                G.GetComponent<G_Controller>().G_Die();
            }
            //なんかだったら

            //画面から離したとき
            if (Input.GetMouseButtonUp(0))
            {
                //文字盤をしまってコインを戻す
                Paper.gameObject.SetActive(false);
                Coin.GetComponent<Coin_Controller>().Return_Coin();

                //コインと重なってたObjectを確認する
                Get_Char = Coin.GetComponent<Coin_Controller>().Tap_Char;
                
                Tap_Object = null;
                G_SE = true;


                //合ってたら
                if (Get_Char == Answer[A_Num[Q_Num]])
                {
                    var color = spriteRenderer.color;

                    //SE
                    Game_SE.GetComponent<Game_SE>().Char_SE();

                    CoolTime = Time.deltaTime;
                    SetTime = CoolTime + 1;
                    //文字の表示
                    Char[Q_Num].gameObject.SetActive(true);
                    Char[Q_Num].GetComponent<Answer_Char>().UI();
                    Get_Char = null;
                    //ムービーシーンへ
                    //SceneManager.LoadScene("MovieScene");
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
                        //ゲームオーバーへ
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
        Scene_Count += 1;
        Answer_Set();
        spriteRenderer = Char[Q_Num].GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Tap();
    }

}

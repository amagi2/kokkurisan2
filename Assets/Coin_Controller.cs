using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Controller : MonoBehaviour
{
    private Vector3 MousePos;//マウスの座標
    private Vector3 WorldPointPos;//世界座標

    //コイン移動
    public void Move_Coin()
    {
        WorldPointPos.z = 0;
        gameObject.transform.position = WorldPointPos;
    }

    //コイン定位置移動
    public void Return_Coin()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Input.mousePosition;
        WorldPointPos = Camera.main.ScreenToWorldPoint(MousePos);
    }
}

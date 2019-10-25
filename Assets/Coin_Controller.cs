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
        pos = Input.mousePosition;
        WorldPointPos = Camera.main.ScreenToWorldPoint(pos);
        if (Input.GetMouseButton(0))
        {
            WorldPointPos.z = 0;
            gameObject.transform.position = WorldPointPos;
            Debug.Log("確認");
        }
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }
        
    }
}

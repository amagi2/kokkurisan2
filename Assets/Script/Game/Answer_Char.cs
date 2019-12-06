using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer_Char : MonoBehaviour
{
    SpriteRenderer sprite;
    float Add_a = 0.05f;//透明度変更値
    float a;            //透明度
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Debug.Log("aaaa");
    }

    //文字背景
    public void UI()
    {
        var color = sprite.color;
        if (a < 1)
        {
            Debug.Log("aaaa");
            a += Add_a;
            color.a = a;
            sprite.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UI();
    }
}

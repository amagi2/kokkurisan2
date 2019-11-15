using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Controller : MonoBehaviour
{
    public GameObject Time_Ui;
    float Set_Time = 60;
    float Time_Num;

    void Time_UI()
    {
        if (Time_Num >= 0)
        {
            Time_Num = Set_Time - Time.time;
            Time_Num = Mathf.Floor(Time_Num);
            Text Time_text = Time_Ui.GetComponent<Text>();
            Time_text.text = "残り時間 " + Time_Num;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time_Num = Set_Time;
    }

    // Update is called once per frame
    void Update()
    {
        Time_UI();

    }
}

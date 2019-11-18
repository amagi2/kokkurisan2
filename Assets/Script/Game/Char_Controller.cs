using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Controller : MonoBehaviour
{
    float Add_Scale = 0.01f;
    float Change_Scale = 0.2f;
    float Add_Pos;
    float Get_Change_Pos;
    string test;


    void Scale()
    {
        Transform mytransform = this.transform;
        Vector3 localScale = mytransform.localScale;
        if (localScale.x <= Change_Scale)
        {
            localScale.x += Add_Scale;
            localScale.y += Add_Scale;
            mytransform.localScale = localScale;
        }
    }

    /*void Move()
    {
        Transform mytransform = this.transform;
        Vector3 worldPos = mytransform.position;
        //if()
    }*/

    void Return_Scale()
    {
        Transform mytransform = this.transform;
        Vector3 localScale = mytransform.localScale;
        localScale.x = 0.1f;
        localScale.y = 0.1f;
        mytransform.localScale = localScale;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Scale();
        if (Input.GetMouseButtonUp(0))
        {
            Return_Scale();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Return_Scale();
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

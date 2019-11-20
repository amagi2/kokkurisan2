using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char : MonoBehaviour
{
    private float Add_Scale = 0.1f;
    private float Change_Scale = 2f;
    private float Add_Pos = 2f;
    private float Change_Pos = 7f;

    public void Scale()
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
    public void Move()
    {
        Transform mytransform = this.transform;
        Vector3 localPos = mytransform.localPosition;
        if (localPos.y <= Change_Pos)
        {
            localPos.x = 0;
            localPos.y += Add_Pos;
            mytransform.localPosition = localPos;
        }
    }

    public void Return_Scale()
    {
        Transform mytransform = this.transform;
        Vector3 localScale = mytransform.localScale;
        localScale.x = 1f;
        localScale.y = 1f;
        mytransform.localScale = localScale;
    }
    public void ReMove()
    {
        Transform mytransform = this.transform;
        Vector3 localPos = mytransform.localPosition;
        localPos.x = 0;
        localPos.y = 0;
        mytransform.localPosition = localPos;
    }


    void Start()
    {

    }

    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Char : MonoBehaviour
{
    private float Add_Scale = 0.1f; //�T�C�Y�ύX�l
    private float Change_Scale = 2f;//�T�C�Y���

    private float Add_Pos = 2f;     //���W�ύX�l
    private float Change_Pos = 7f;  //���W���
    
    //�����T�C�Y�ύX
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
    public void ReScale()
    {
        Transform mytransform = this.transform;
        Vector3 localScale = mytransform.localScale;
        localScale.x = 1f;
        localScale.y = 1f;
        mytransform.localScale = localScale;
    }

    //�����ړ�
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
    public void ReMove()
    {
        Transform mytransform = this.transform;
        Vector3 localPos = mytransform.localPosition;
        localPos.x = 0;
        localPos.y = 0;
        mytransform.localPosition = localPos;
    }

    //���C���[�ύX
    public void Layer()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 5;
    }
    public void ReLayer()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 3;
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}

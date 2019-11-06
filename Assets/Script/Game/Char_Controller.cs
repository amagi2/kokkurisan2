using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Controller : MonoBehaviour
{
    float Change_Scale = 0.01f;

    void Scale()
    {
        Transform mytransform = this.transform;
        Vector3 localScale = mytransform.localScale;
        localScale.x += Change_Scale;
        localScale.y += Change_Scale;
        mytransform.localScale = localScale;

        if (localScale.x >= 0.15 || localScale.x <= 0.05) 
        {
            Change_Scale *= -1;
        }
    }

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

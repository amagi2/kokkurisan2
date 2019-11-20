using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_Controller : MonoBehaviour
{
    //private float Add_Scale = 0.01f;
    //private float Change_Scale = 0.2f;
    //private float width;
    //private float height;
    [SerializeField]
    private GameObject charObject;

    /*void Scale()
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

    void Return_Scale()
    {
        Transform mytransform = this.transform;
        Vector3 localScale = mytransform.localScale;
        localScale.x = 0.1f;
        localScale.y = 0.1f;
        mytransform.localScale = localScale;
    }*/

    private void OnCollisionStay2D(Collision2D collision)
    {
        charObject.GetComponent<Char>().Scale();
        charObject.GetComponent<Char>().Move();
        if (Input.GetMouseButtonUp(0))
        {
            charObject.GetComponent<Char>().Return_Scale();
            charObject.GetComponent<Char>().ReMove();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        charObject.GetComponent<Char>().Return_Scale();
        charObject.GetComponent<Char>().ReMove();
    }



    void Start()
    {

    }

    void Update()
    {
        
    }
}

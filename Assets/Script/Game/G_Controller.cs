﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Controller : MonoBehaviour
{
<<<<<<< HEAD
=======
<<<<<<< HEAD
    public void G_Die()
    {
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
=======
>>>>>>> aa8eb78f4a3a631a5dc5d49c619fb34fa71f91cf
    private int G_Rand;
    
    float i;

    public void G_Die()
    {
        Destroy(gameObject);
    }

    void G_Move()
    {
        //位置確認
        //X=3.5,3.5
        //Y=0,4.5
        //方向指定
        Transform mytransform = this.transform;
        Vector3 G_Pos = mytransform.position;
        Vector3 G_Angle = mytransform.eulerAngles;
        if (G_Pos.x < -0.5)
        {
            G_Rand = Random.Range(-60, 60);
        }
        else if (G_Pos.x > 3.5)
        {
            G_Rand = Random.Range(120, 240);
        }
        else if (G_Pos.y < -4)
        {
            G_Rand = Random.Range(30, 150);
        }
        else if (G_Pos.y > -2)
        {
            G_Rand = Random.Range(210, 330);
        }
        //動く
        G_Angle.z = G_Rand;
        mytransform.eulerAngles = G_Angle;
        this.gameObject.transform.Translate(0.07f, 0, 0);
    }
    

    // Start is called before the first frame update
    void Start()
    {

<<<<<<< HEAD
=======
>>>>>>> ootsuka/mock
>>>>>>> aa8eb78f4a3a631a5dc5d49c619fb34fa71f91cf
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        G_Move();
=======
<<<<<<< HEAD

=======
        G_Move();
>>>>>>> ootsuka/mock
>>>>>>> aa8eb78f4a3a631a5dc5d49c619fb34fa71f91cf
    }
}

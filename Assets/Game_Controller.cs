using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    GameObject Tap;
    string Name;
    public GameObject coin;

    void Ray()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tap = null;
            Name = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            if (hit2D)
            {
                Tap = hit2D.transform.gameObject;
                Name = hit2D.transform.gameObject.name;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (Name == "Coin")
            {
                coin.GetComponent<Coin_Controller>().Move_Coin();
            }
            Debug.Log(Tap);
        }
        if (Input.GetMouseButtonUp(0))
        {
            coin.GetComponent<Coin_Controller>().Return_Coin();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray();
    }
}

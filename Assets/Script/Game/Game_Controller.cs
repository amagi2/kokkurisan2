using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public GameObject Coin;
    public GameObject Paper;
    string Tap_Object;

    void Tap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tap_Object = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2D)
            {
                Tap_Object = hit2D.transform.gameObject.name;
            }
        }
    }

    void Command()
    {
        if (Input.GetMouseButton(0))
        {
            if (Tap_Object == "Coin")
            {
                Paper.gameObject.SetActive(true);
                Coin.GetComponent<Coin_Controller>().Move_Coin();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Paper.gameObject.SetActive(false);
            Coin.GetComponent<Coin_Controller>().Return_Coin();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tap();
        Command();
    }
}

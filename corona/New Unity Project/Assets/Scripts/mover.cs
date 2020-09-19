using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public float speed = 10f;
    float x, y;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        pos = transform.position;


        if (x != 0 && y != 0)
        {
            pos.x += (x * speed * Time.deltaTime);
            pos.y += (y * speed * Time.deltaTime);
        }
        else
        {


            if (x != 0)
                pos.x += (x * 1.414f * speed * Time.deltaTime);
            if (y != 0)
                pos.y += (y * 1.414f * speed * Time.deltaTime);
        }


        transform.position = pos;
    }
}

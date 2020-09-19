using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooker : MonoBehaviour
{
    float x, y;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;

        pos = Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2((y-pos.y), (x-pos.x)) * Mathf.Rad2Deg;

        transform.eulerAngles =new Vector3(0,0,angle);
    }
}

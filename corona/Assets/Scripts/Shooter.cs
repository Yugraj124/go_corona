using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject energyBallPrefab;
    public Transform gunTip;

    public float shootPower = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject energyBall = Instantiate(energyBallPrefab, gunTip.position,Quaternion.identity);
            
            Vector3 playerAngle = transform.eulerAngles;
            energyBall.transform.eulerAngles = playerAngle;
            energyBall.transform.Rotate(Vector3.forward * 90);
            
         //   energyBall.transform.position = transform.position + (transform.forward*10);   

            float shootAngleDeg = transform.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 shootAngle = new Vector2(Mathf.Cos(shootAngleDeg), Mathf.Sin(shootAngleDeg));
            energyBall.GetComponent<Rigidbody2D>().AddForce(shootAngle * shootPower, ForceMode2D.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject energyBallPrefab;
    public Transform gunTip;

    public float shootCooldown = 0.3f;
    public float shootCooldownIncrease = 0.1f;
    public float shootPower = 5.0f;

    private float timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeElapsed >= shootCooldown)
        {
            GameObject energyBall = Instantiate(energyBallPrefab, gunTip.position,Quaternion.identity);
            
            Vector3 playerAngle = transform.eulerAngles;
            energyBall.transform.eulerAngles = playerAngle;
            energyBall.transform.Rotate(Vector3.forward * 90); 

            float shootAngleDeg = transform.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 shootAngle = new Vector2(Mathf.Cos(shootAngleDeg), Mathf.Sin(shootAngleDeg));
            energyBall.GetComponent<Rigidbody2D>().AddForce(shootAngle * shootPower, ForceMode2D.Impulse);
            timeElapsed = 0;
        }
    }
}

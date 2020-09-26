using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Virus : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 dir = (Vector2)target.position - rb.position;

            dir.Normalize();

            float rotateAmount = Vector3.Cross(dir, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
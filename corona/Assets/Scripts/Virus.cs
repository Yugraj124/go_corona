using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Virus : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    public GameObject Vaccine;
    public GameObject deathEffect;
    [Range(0,1)]
    public float vaccineDropProb = 0.2f;
    public Score ScoreObject;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScoreObject = FindObjectOfType<Score>();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            int rnd = Random.Range(1, 100);
            if (rnd <= vaccineDropProb*100)
                Instantiate(Vaccine, transform.position, Quaternion.identity);

            ScoreObject.ScoreAdd();
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
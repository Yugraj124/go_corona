using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 3f;
    public float speedDecrease = 0.2f;
    public GameObject audioObject;
    public AudioClip walkingSound;

    float x, y;
    Vector2 pos;
    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = audioObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        pos = transform.position;


        if (x != 0 && y != 0)
        {
            if (gameObject && !animator.GetBool("isWalking"))
            {
                audioSource.clip = walkingSound;
                audioSource.loop = true;
                audioSource.Play();
            }
            animator.SetBool("isWalking", true);
            pos.x += (x * speed * Time.deltaTime);
            pos.y += (y * speed * Time.deltaTime);
        }
        else if (x != 0 || y != 0)
        {
            if (gameObject && !animator.GetBool("isWalking"))
            {
                audioSource.clip = walkingSound;
                audioSource.loop = true;
                audioSource.Play();
            }
            animator.SetBool("isWalking", true);
            if (x != 0)
                pos.x += (x * 1.414f * speed * Time.deltaTime);
            if (y != 0)
                pos.y += (y * 1.414f * speed * Time.deltaTime);
        }
        else
        {
            if (gameObject && animator.GetBool("isWalking"))
            {
                audioSource.Stop();
            }
            animator.SetBool("isWalking", false);
        }


        transform.position = pos;
    }
}

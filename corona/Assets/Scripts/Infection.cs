using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{

    private Healthbar healthBar;
    public float TimeToDie = 10;
    private bool isInfected = false;
    private float ElapsedTime;
    public int maxSpace = 3;
    private int vaccineAmount;


    private void Start()
    {
        healthBar = FindObjectOfType<Healthbar>();
        healthBar.max= TimeToDie;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Virus")
        {
            isInfected = true;
            Destroy(collision.gameObject);
        }
        else if(collision.transform.tag == "Vaccine")
        {
            vaccineAmount++;
            vaccineAmount = Mathf.Clamp(vaccineAmount, 0, maxSpace);
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if(isInfected)
        {
            ElapsedTime += Time.deltaTime;
           
            healthBar.SetValue(Mathf.Clamp(ElapsedTime, 0, TimeToDie));
            if (ElapsedTime > TimeToDie)
                Destroy(gameObject);

        }
    }
}

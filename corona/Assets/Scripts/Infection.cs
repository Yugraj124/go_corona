using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Infection : MonoBehaviour
{

    private Healthbar healthBar;
    public float TimeToDie = 10;
    public int maxSpace = 3;
    public float timeDecrease = 1.5f;
    public Text VaccineText;

    private int vaccineAmount;
    private bool isInfected = false;
    private float ElapsedTime;

    private void Awake()
    {
        healthBar = FindObjectOfType<Healthbar>();
        healthBar.max= TimeToDie;
        VaccineText.text = "x0";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Virus")
        {
            if(!isInfected)
                isInfected = true;
            else
            {
                ElapsedTime += timeDecrease;
                healthBar.SetValue(Mathf.Clamp(ElapsedTime, 0, TimeToDie));
            }
            Destroy(collision.gameObject);
        }
        else if(collision.transform.tag == "Vaccine")
        {
            vaccineAmount++;
            vaccineAmount = Mathf.Clamp(vaccineAmount, 0, maxSpace);
            VaccineText.text = "x" + vaccineAmount.ToString();
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInfected)
        {
            if (vaccineAmount > 0)
            {
                vaccineAmount--;
                vaccineAmount = Mathf.Clamp(vaccineAmount, 0, maxSpace);
                VaccineText.text = "x" + vaccineAmount.ToString();
                isInfected = false;
            }
        }

        if (gameObject && isInfected)
        {
            ElapsedTime += Time.deltaTime;
           
            healthBar.SetValue(Mathf.Clamp(ElapsedTime, 0, TimeToDie));
            if (ElapsedTime > TimeToDie)
                Destroy(gameObject);

            GetComponent<Shooter>().shootCooldown = 0.3f + ElapsedTime * GetComponent<Shooter>().shootCooldownIncrease;
            GetComponent<Mover>().speed = 3f - ElapsedTime * GetComponent<Mover>().speedDecrease;
        }
        else if (ElapsedTime > 0)
        {
            ElapsedTime -= Time.deltaTime * 2;
            ElapsedTime = (Mathf.Clamp(ElapsedTime, 0, TimeToDie));
            healthBar.SetValue(ElapsedTime);

            GetComponent<Shooter>().shootCooldown = 0.3f + ElapsedTime * GetComponent<Shooter>().shootCooldownIncrease;
            GetComponent<Mover>().speed = 3f - ElapsedTime * GetComponent<Mover>().speedDecrease;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Infection : MonoBehaviour
{

    private Healthbar healthBar;
    public float TimeToDie = 10;
    public GameObject audioObject;
    public AudioClip deathSound;
    public AudioClip syringeSound;
    public int maxSpace = 3;
    public float timeDecrease = 1.5f;
    public Text VaccineText;
    public GameObject UIManager;

    AudioSource audioSource;
    AudioSource audioSource2;
    private int vaccineAmount;
    private bool isInfected = false;
    private float ElapsedTime;
    private SpriteRenderer color;
    private int colorDec = 15;

    private void Awake()
    {
        healthBar = FindObjectOfType<Healthbar>();
        healthBar.max= TimeToDie;
        VaccineText.text = "x0";
        color = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource2 = audioObject.GetComponent<AudioSource>();
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
                audioSource.PlayOneShot(syringeSound);
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
            {
                audioSource2.loop = false;
                audioSource2.PlayOneShot(deathSound);
                UIManager.GetComponent<GameOver>().PlayerDead = true;
                Destroy(gameObject);
            }

            GetComponent<Shooter>().shootCooldown = 0.3f + ElapsedTime * GetComponent<Shooter>().shootCooldownIncrease;
            GetComponent<Mover>().speed = 3f - ElapsedTime * GetComponent<Mover>().speedDecrease;
            color.color = new Color((250-ElapsedTime*colorDec)/255, 1, (250 - ElapsedTime * colorDec)/255, 1);
        }
        else if (ElapsedTime > 0)
        {
            ElapsedTime -= Time.deltaTime * 2;
            ElapsedTime = (Mathf.Clamp(ElapsedTime, 0, TimeToDie));
            healthBar.SetValue(ElapsedTime);

            GetComponent<Shooter>().shootCooldown = 0.3f + ElapsedTime * GetComponent<Shooter>().shootCooldownIncrease;
            GetComponent<Mover>().speed = 3f - ElapsedTime * GetComponent<Mover>().speedDecrease;
            color.color = new Color((250 - ElapsedTime * colorDec)/255, 1, (250 - ElapsedTime * colorDec)/255, 1);
        }
    }
}

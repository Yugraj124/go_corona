using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject virusPrefab;
    public Transform target;
    public float spawnCooldown = 7f;

    float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        
        if (timeElapsed > spawnCooldown)
        {
            timeElapsed = 0;
            int side = Random.Range(1, 5);
            float temp = Random.Range(-10f, 10f);
            Vector3 location = target.transform.position;

            if (side == 1)
            {
                location.x -= 10f;
                location.y += temp;
            }
            else if (side == 2)
            {
                location.y -= 10f;
                location.x += temp;
            }
            else if (side == 3)
            {
                location.x += 10f;
                location.y += temp;
            }
            else if (side == 4)
            {
                location.y += 10f;
                location.x += temp;
            }

            GameObject virus = Instantiate(virusPrefab, location, Quaternion.identity);
            virus.GetComponent<Virus>().target = target;
        }
    }
}

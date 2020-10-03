using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float spawnCooldown = 5f;
    public Spawner spawner;

    private void Awake()
    {
        spawner.setCooldown(spawnCooldown);
    }
    public void scoreChanged()
    {
        if (spawnCooldown > 1)
            spawnCooldown = spawnCooldown - 0.5f;
        else if (spawnCooldown > 0.2)
            spawnCooldown = spawnCooldown - 0.1f;
        else
            spawnCooldown = spawnCooldown * 1;
        spawner.setCooldown(spawnCooldown);
    }
}

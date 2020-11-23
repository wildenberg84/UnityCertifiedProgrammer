using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnableUnits;
    public GameObject[] spawnablePowerups;
    private GameObject player;
    public float spawnRange = 24; // vertical

    public int enemyCount = 0;
    public int waveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(enemyCount == 0)
        {
            waveCount++;

            for(int i = 0; i < waveCount; i++)
            {
                SpawnRandomUnit();
            }

            SpawnRandomPowerup();
        }
    }

    void SpawnRandomUnit()
    {
        int index = Random.Range(0, spawnableUnits.Length);
        float xLoc = Random.Range(-spawnRange, spawnRange);

        GameObject spawn = Instantiate(spawnableUnits[index], new Vector3(xLoc, 0.75f, 25), spawnableUnits[index].transform.rotation);

        if (spawn.CompareTag("Friendly"))
        {
            // ignore collider to allow friendly to pass through
            Physics.IgnoreCollision(spawn.GetComponent<Collider>(), player.GetComponent<Collider>());
        }
    }

    void SpawnRandomPowerup()
    {
        int index = Random.Range(0, spawnablePowerups.Length);
        float xLoc = Random.Range(-spawnRange, spawnRange);

        Instantiate(spawnablePowerups[index], new Vector3(xLoc, 0.75f, 25), spawnableUnits[index].transform.rotation);
    }
}

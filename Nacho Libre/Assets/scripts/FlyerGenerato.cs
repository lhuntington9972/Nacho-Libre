using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerGenerato : MonoBehaviour
{
    public GameObject flyers;
    private float betweenSpawns;
    private Vector3 spawnLocation;
    private float totalSpawnCount;

    // Start is called before the first frame update
    void Start()
    {
        betweenSpawns = 3f;
        totalSpawnCount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        Debug.Log("spawning initiated!");
        for (int i = 0; i < 10; i++)
        {
            if (totalSpawnCount >= 5)
            {
                betweenSpawns = 1f;
            }
            yield return new WaitForSeconds(betweenSpawns);
            spawnLocation = new Vector3(Mathf.Round(Random.Range(-14f, 14f)), 1, Mathf.Round(Random.Range(-14f, 14f)));
            Instantiate(flyers, spawnLocation, Quaternion.identity);
            totalSpawnCount += 1;
        }
        Debug.Log("spawning completed successfully!");
    }
}

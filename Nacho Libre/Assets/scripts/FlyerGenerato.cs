using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerGenerato : MonoBehaviour
{
    public GameObject flyer1;
    public GameObject flyer2;
    public GameObject flyer3;
    private GameObject flyers;
    private float flyernum;
    private float betweenSpawns;
    private Vector3 spawnLocation;
    private float totalSpawnCount;

    // Start is called before the first frame update
    void Start()
    {
        betweenSpawns = 3f;
        totalSpawnCount = 0f;
        flyers = flyer1;
        StartCoroutine(Spawn());
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
        for (int i = 0; i < 25; i++)
        {
            if (totalSpawnCount >= 15)
            {
                betweenSpawns = 1f;
            } else if (totalSpawnCount >= 5)
            {
                betweenSpawns = 2f;
            }
            flyernum = Random.Range(1, 4);
            if (flyernum == 1)
            {
                flyers = flyer1;
            } else if (flyernum == 2)
            {
                flyers = flyer2;
            } else if (flyernum == 3)
            {
                flyers = flyer3;
            }
            yield return new WaitForSeconds(betweenSpawns);
            spawnLocation = new Vector3(Mathf.Round(Random.Range(-14f, 14f)), 1, Mathf.Round(Random.Range(-14f, 14f)));
            Instantiate(flyers, spawnLocation, Quaternion.identity);
            totalSpawnCount += 1;
        }
        Debug.Log("spawning completed successfully!");
    }
}

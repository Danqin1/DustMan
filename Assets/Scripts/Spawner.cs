using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject[] trashes = new GameObject[8];
    public float timeBetweenSpawns = 1;
    private Vector2[] spawnPoints;
    void Start()
    {
        spawnPoints = new Vector2[4];
        spawnPoints[0] = point1.transform.position;
        spawnPoints[1] = point2.transform.position;
        spawnPoints[2] = point3.transform.position;
        spawnPoints[3] = point4.transform.position;
       StartCoroutine( WaitAndSpawn());
    }
    IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        Instantiate(ChooseTrash(), ChooseLine(), Quaternion.identity);
        StartCoroutine(WaitAndSpawn());
    }
    private GameObject ChooseTrash()
    {
        int trashNr = UnityEngine.Random.Range(0, 8);
        return trashes[trashNr];
    }
    private Vector2 ChooseLine()
    {
        int lineNr = UnityEngine.Random.Range(0, 4);
        return spawnPoints[lineNr];
    }
}

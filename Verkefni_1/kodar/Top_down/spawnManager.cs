using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // set upp 'functions'
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 18;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    void Start()
    {
        // keyri 'SpawnRandomAnimal' þegar biðin eru búin (startDelay)
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }
    void SpawnRandomAnimal() 
    {
        // dýrin birtast á slembi stað
        int animalndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalndex], spawnPos, animalPrefabs[animalndex].transform.rotation);
    }
}

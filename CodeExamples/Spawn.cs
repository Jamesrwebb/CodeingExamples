using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{

    public GameObject[] myObjects;

    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

	void Start () {
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}

    public void SpawnObject() {
      int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));

            Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
       

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

    public GameObject fruit;
    public Transform[] spawnPoints;
    public float minDelay = 0.1f;
    public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnFruits());
    }
	
    IEnumerator SpawnFruits()
    {
        while(true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);


            //Spawn Fruit
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            GameObject spawnedFruit = Instantiate(fruit, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
            
        }
    }

}

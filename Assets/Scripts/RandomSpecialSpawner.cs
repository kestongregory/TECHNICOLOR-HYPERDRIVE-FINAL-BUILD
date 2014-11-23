using UnityEngine;
using System.Collections;

public class RandomSpecialSpawner : MonoBehaviour {

	public GameObject[] spawnObject;
	public float xRange = 1.0f;
	public float yRange = 1.0f;
	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 10.0f;
	public int counter = 0;
	
	// Use this for initialization
	void Start () {
		Invoke ("SpawnWall", Random.Range(minSpawnTime, maxSpawnTime));
	}
	
	void SpawnWall(){
		float xOffset = Random.Range(-xRange, xRange);
		float yOffset = Random.Range(-yRange, yRange);
		int spawnObjectIndex = Random.Range (0, spawnObject.Length);
		Instantiate(spawnObject[spawnObjectIndex],transform.position + new Vector3(xOffset,yOffset,0.0f), spawnObject[spawnObjectIndex].transform.rotation);
		Invoke ("SpawnWall", Random.Range(minSpawnTime, maxSpawnTime));
	}

	void Update(){
		if (ScoreManager.Instance.currentMultiply == 10 ||
			ScoreManager.Instance.currentMultiply == 5) {
			xRange = 50f;
			yRange = 50f;
		} else {
			xRange = 1000f;
			yRange = 1000f;
		}
	}
}

using UnityEngine;
using System.Collections;

public class RandomAsteroidSpawner : MonoBehaviour {

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
		if (SpeedManager.Instance.currentSpeed >= 100 &&
		    SpeedManager.Instance.currentSpeed < 200) {
			minSpawnTime = 1f;
			maxSpawnTime = 2f;
		}else		if (SpeedManager.Instance.currentSpeed >= 200 &&
		           SpeedManager.Instance.currentSpeed < 300) {
			minSpawnTime = 0.75f;
			maxSpawnTime = 1f;
		}else		if (SpeedManager.Instance.currentSpeed >= 300) {
			minSpawnTime = 0.5f;
			maxSpawnTime = 0.75f;
		}
	}
}

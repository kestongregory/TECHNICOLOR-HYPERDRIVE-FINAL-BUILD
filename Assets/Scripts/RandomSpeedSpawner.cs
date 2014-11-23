using UnityEngine;
using System.Collections;

public class RandomSpeedSpawner : MonoBehaviour {

	public GameObject[] spawnObject;
	public float xRange = 1.0f;
	public float yRange = 1.0f;
	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 10.0f;
	public int counter = 0;

	public bool Hardcore = false;

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

	void Update (){
		if (SpeedManager.Instance.currentSpeed >= 100 &&
			SpeedManager.Instance.currentSpeed < 150) {
				minSpawnTime = 3.5f;
				maxSpawnTime = 3.5f;
			} else		if (SpeedManager.Instance.currentSpeed >= 150 &&
						SpeedManager.Instance.currentSpeed < 200) {
				minSpawnTime = 2.5f;
					maxSpawnTime = 3.5f;
			} else		if (SpeedManager.Instance.currentSpeed >= 200 &&
						SpeedManager.Instance.currentSpeed < 250) {
				minSpawnTime = 1f;
				maxSpawnTime = 2.5f;
			} else		if (SpeedManager.Instance.currentSpeed >= 250) {
				minSpawnTime = 1f;
				maxSpawnTime = 2f;
			} else if (SpeedManager.Instance.currentSpeed >= 350) {
				minSpawnTime = 10f;
				maxSpawnTime = 10f;
		}

		if (Hardcore == true) {
			minSpawnTime = 0.1f;
			maxSpawnTime = 0.1f;
		}
	}
}

using UnityEngine;
using System.Collections;

public class RandomEnemySpawner : MonoBehaviour {

	public GameObject[] spawnObject;
	public float xRange = 1.0f;
	public float yRange = 1.0f;
	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 10.0f;
	public bool scoreMet = false;
	
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
		if (minSpawnTime <= .3f) {
			minSpawnTime = .6f;
			maxSpawnTime = .6f;
		} else{
			if (ScoreManager.Instance.score2 % 50 == 0 && 
			    ScoreManager.Instance.currentMultiply == 1 /*&& ScoreManager.Instance.score2 != 0*/) {
				minSpawnTime *= .999f;
				maxSpawnTime *= .999f;
			}else if (ScoreManager.Instance.currentMultiply == 10 ||
			          ScoreManager.Instance.currentMultiply == 10/*&& ScoreManager.Instance.score2 != 0*/) {
				minSpawnTime *= .999f;
				maxSpawnTime *= .999f;
			}else if (ScoreManager.Instance.currentMultiply == 3 ||
			 		   ScoreManager.Instance.currentMultiply == 7 ||
			 		   ScoreManager.Instance.currentMultiply == 9/*&& ScoreManager.Instance.score2 != 0*/) {
				minSpawnTime *= .9999f;
				maxSpawnTime *= .9999f;
				if(ScoreManager.Instance.score2 % 5 == 0){
					minSpawnTime *= .999f;
					maxSpawnTime *= .999f;
				}
			}else if(ScoreManager.Instance.currentMultiply == 2 ||
			         ScoreManager.Instance.currentMultiply == 4||
			         ScoreManager.Instance.currentMultiply == 6||
			         ScoreManager.Instance.currentMultiply == 8){
				minSpawnTime *= .9999f;
				maxSpawnTime *= .9999f;
				if(ScoreManager.Instance.score2 % 6 == 0){
					minSpawnTime *= .999f;
					maxSpawnTime *= .999f;
				}
			}
		}
	}
}

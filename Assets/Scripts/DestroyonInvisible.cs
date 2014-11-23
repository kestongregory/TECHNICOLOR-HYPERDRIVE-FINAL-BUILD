using UnityEngine;
using System.Collections;

public class DestroyonInvisible : MonoBehaviour {
	
	public bool destroySelf = true;
	public GameObject[] destroyObjects;

	// Use this for initialization
	void OnBecameInvisible(){
		if (destroySelf) {
			Destroy (gameObject);
		}
		foreach (GameObject obj in destroyObjects) {
			Destroy (obj);
		}
	}
}

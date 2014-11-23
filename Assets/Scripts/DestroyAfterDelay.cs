using UnityEngine;
using System.Collections;

public class DestroyAfterDelay : MonoBehaviour {
	public float delay;

	// Use this for initialization
	void Start () {
		Invoke ("DestroyNow", delay);
	}
	
	void DestroyNow(){
		Destroy (gameObject);
	}
}

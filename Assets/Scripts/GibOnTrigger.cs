using UnityEngine;
using System.Collections;

public class GibOnTrigger : MonoBehaviour {
	public string[] tags;
	public GameObject gib;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		foreach (string tag in tags) {
			if(col.tag == tag){
				Instantiate (gib,transform.position,Random.rotation);
				Destroy (gameObject);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class CometMoveForward : MonoBehaviour {

	public float speed = 1.0f;
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * speed * Time.deltaTime;
	}

}

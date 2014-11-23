using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour {

	public float objectSpeed = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

			transform.position += transform.forward*objectSpeed*Time.deltaTime;

	}
}

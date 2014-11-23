using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour 
{
	public float speed = 1.0f;
	public float speedBoost = 10.0f;
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * speed * Time.deltaTime;
		//speed+=speedBoost; //Speeds up over time
	}

	//void OnTriggerEnter(){
	//	speed+=speedBoost; //Speeds up when passing a ring.
	//}
}

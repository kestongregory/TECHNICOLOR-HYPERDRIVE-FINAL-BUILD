using UnityEngine;
using System.Collections;

public class SpasmOnTrigger : MonoBehaviour {

	public float speedUpAmount = 1.0f;
	public float coolDownTime = 1.0f;
	
	private bool inCoolDown = false;
	
	void OnTriggerEnter(){
		if (!inCoolDown) {
//			ScrollTexture.scrollSpeedX = 10000;
//			ScrollTexture.scrollSpeedY = 10000;
			//MoveForward.speed+=MoveForward.speedBoost;
			inCoolDown = true;
			Invoke ("Uncool", coolDownTime);
		}
	}
	
	void Uncool(){
		inCoolDown = false;
//		ScrollTexture.scrollSpeedX = 0;
//		ScrollTexture.scrollSpeedY = 0;
	}
}

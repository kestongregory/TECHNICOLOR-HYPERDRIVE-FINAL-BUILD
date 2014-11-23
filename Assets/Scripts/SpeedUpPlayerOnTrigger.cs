using UnityEngine;
using System.Collections;

public class SpeedUpPlayerOnTrigger : MonoBehaviour {

	public float speedUpAmount = 1.0f;
	public float coolDownTime = 1.0f;

	private bool inCoolDown = false;

	void OnTriggerEnter(){
		if (!inCoolDown) {
			SpeedManager.Instance.SpeedUpPlayer (speedUpAmount);
			//MoveForward.speed+=MoveForward.speedBoost;
			inCoolDown = true;
			Invoke ("Uncool", coolDownTime);
		}
	}

	void Uncool(){
		inCoolDown = false;
	}
}

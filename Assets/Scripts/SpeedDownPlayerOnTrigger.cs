using UnityEngine;
using System.Collections;

public class SpeedDownPlayerOnTrigger : MonoBehaviour {

	public float speedDownAmount = 1.0f;
	public float coolDownTime = 1.0f;

	private bool inCoolDown = false;

	void OnTriggerEnter(){
		if (!inCoolDown) {
			SpeedManager.Instance.SpeedDownPlayer (speedDownAmount);
			inCoolDown = true;
			Invoke ("Uncool", coolDownTime);
		}
	}

	void Uncool(){
		inCoolDown = false;
	}
}

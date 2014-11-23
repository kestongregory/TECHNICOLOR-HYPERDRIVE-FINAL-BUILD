using UnityEngine;
using System.Collections;

public class HealPlayerOnTrigger : MonoBehaviour {

	public float healAmount = 1.0f;
	public float coolDownTime = 1.0f;

	private bool inCoolDown = false;

	void OnTriggerEnter(){
		if (!inCoolDown) {
			HealthManager.Instance.HealPlayer (healAmount);
			inCoolDown = true;
			Invoke ("Uncool", coolDownTime);
		}
	}

	void Uncool(){
		inCoolDown = false;
	}
}

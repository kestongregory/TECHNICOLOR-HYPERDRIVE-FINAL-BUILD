using UnityEngine;
using System.Collections;

public class UpMultiplierOnTrigger : MonoBehaviour {

	public int upAmount = 1;
	public float coolDownTime = 1.0f;

	//public int ringCount = 0;

	private bool inCoolDown = false;

	void OnTriggerEnter(){
		//ringCount++;
		if (!inCoolDown /*&& ringCount%10 == 0*/) {
			//ScoreManager.Instance.UpMultiplier (upAmount);
			inCoolDown = true;
			Invoke ("Uncool", coolDownTime);
		}
	}

	void Uncool(){
		inCoolDown = false;
	}
}

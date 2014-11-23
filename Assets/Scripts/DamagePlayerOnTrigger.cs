using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
public class DamagePlayerOnTrigger : MonoBehaviour {

	public float damageAmount = 1.0f;
	public float coolDownTime = 1.0f;

	public bool destroySelf = true;
	public GameObject[] destroyObjects;

	//Lower Multiplier by 1
	public int lowerMultiplyAmount = 1;

	private bool inCoolDown = false;

	public AudioClip impact;

	void OnTriggerEnter(){
		if (!inCoolDown) {
			HealthManager.Instance.DamagePlayer (damageAmount);
			ScoreManager.Instance.LowerMultiplier (lowerMultiplyAmount); //Lower Multiplier by 1 when triggered
			inCoolDown = true;

			audio.PlayOneShot(impact, 1);

			Invoke ("Uncool", coolDownTime);
			
			if (destroySelf) {
				Destroy (gameObject);
			}
			foreach (GameObject obj in destroyObjects) {
				Destroy (obj);
			}
		}
	}

	void Uncool(){
		inCoolDown = false;
	}
	
}

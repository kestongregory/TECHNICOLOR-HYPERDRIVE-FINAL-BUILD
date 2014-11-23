using UnityEngine;
using System.Collections;

public class ExplosionOnTrigger : MonoBehaviour {

	public ParticleSystem explosion;

	void Start () {
		// You can use particleSystem instead of
		// gameObject.particleSystem.
		// They are the same, if I may say so
		//particleSystem.emissionRate = 0;
	}
	
	void Update () {
		if (HealthManager.Instance.isHit == true) {
			Instantiate (explosion, transform.position, Quaternion.identity);
			explosion.Emit (1000);
			Debug.Log ("Explode");
		}
	}
}

using UnityEngine;
using System.Collections;

public class SoundOnTrigger : MonoBehaviour {

	public GameObject player;
	public AudioSource sound;

	void Awake(){
		if (sound == null) {
			sound = GameObject.Find ("ow").GetComponent<AudioSource>();
		}
	}

	void OnTriggerEnter(){
		sound.Play ();
	}
}

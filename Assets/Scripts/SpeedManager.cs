//SINGLETON
using UnityEngine;
using System.Collections;
	
public class SpeedManager : MonoBehaviour {
	//SINGLETON
	private static SpeedManager instance = null;
	public static SpeedManager Instance
	{
		get{ return instance;}
	}
	void Awake(){
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;		
		}
		DontDestroyOnLoad (this.gameObject);
		gameObject.name = "$SpeedManager";
	}
	//ENDSINGLETON

	public Transform healthDisplay;
	public float maxSpeed = 250.0f;
	public float minSpeed = 25.0f;
	public float currentSpeed = 25.0f;

	public AudioClip speedUpTune;

	// Use this for initialization
	void Start () {
		currentSpeed = minSpeed;
	}

	//void OnGUI(){
	//	GUILayout.Label ("SPEED: " + currentSpeed);
	//}

	public void SpeedDownPlayer(float speedDownAmount){
		if (speedDownAmount < 0) {
			Debug.LogError ("Cannot post a negative value to SpeedDownPlayer. Please use SpeedUpPlayer instead.");
			return;
		}

		currentSpeed -= speedDownAmount;
		if (currentSpeed < minSpeed) {
			currentSpeed = minSpeed;
		}
	}
	
	public void SpeedUpPlayer(float speedUpAmount){
		if (speedUpAmount < 0) {
			Debug.LogError("Cannot post a negative value to SpeedUpPlayer. Please use SpeedDownPlayer instead.");
			return;
		}
		currentSpeed += speedUpAmount;
		
		audio.PlayOneShot(speedUpTune, 1);
		
		if (currentSpeed > maxSpeed) {
			currentSpeed = maxSpeed;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * currentSpeed * Time.deltaTime;

		//DISPLAY TEST
		//if (Input.GetButtonDown ("Fire1"))
		//{
		//	currentSpeed += 100;

		//}
	}
}


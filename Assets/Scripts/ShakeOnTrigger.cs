using UnityEngine;
using System.Collections;

public class ShakeOnTrigger : MonoBehaviour {

	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay;
	public float shake_intensity;
	public float decayValue = 1.0f;
	public float intensityValue = 1.0f;
	public bool Shaking = false;

	//public float positionX = 1.0f;
	//public float positionY = 1.0f;
	//public float positionZ = 1.0f;
	private float rotationX = 0.0f;
	private float rotationY = 0.0f;
	private float rotationZ = 0.0f;
	public Transform MainCamera;


	/*void OnGUI (){
		if (GUI.Button (new Rect (20,40,80,20), "Shake")){
			Shake ();
		}
	}*/


	void Update (){

		if (HealthManager.Instance.isHit == true) {
			Shake ();
		}

		if (shake_intensity > 0){
			//transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			transform.rotation = new Quaternion(
				originRotation.x + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.y + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.z + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.w + Random.Range (-shake_intensity,shake_intensity) * .2f);
			shake_intensity -= shake_decay;
		}
		if (shake_intensity <= 0) {
			Shaking = false;
		}

		Vector2 lockPosition = MainCamera.position;
		Quaternion lockRotation = MainCamera.rotation;
		if(Shaking != true){
			//lockPosition.x = positionX;
			//lockPosition.y = positionY;
			//transform.position = lockPosition;
			lockRotation.x = rotationX;
			lockRotation.y = rotationY;
			lockRotation.z = rotationZ;
			transform.rotation = lockRotation;
		}
	}
	
	void Shake(){
		originPosition = transform.position;
		originRotation = transform.rotation;
		shake_intensity = intensityValue;
		shake_decay = decayValue;
		Shaking = true;
	}

}

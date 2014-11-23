using UnityEngine;
using System.Collections;

public class BankTrash : MonoBehaviour {
	public float doubleTapDelay = 0.2f;
	public float barrelRollDuration = 1.0f;
	
	//	private float time = float.MaxValue;
	//	private bool buttonDown = false;
	//	private bool inBarrelRoll = false;
	
	// Update is called once per frame
	void Update () 
	{
		//		if (!inBarrelRoll) 
		//		{
		float bankAxis = Input.GetAxis ("Bank");
		
		//Single axis method (windows/keyboard)
		Vector3 newRotationEuler = transform.rotation.eulerAngles;
		newRotationEuler.z = -90 * bankAxis;
		Quaternion newQuat = Quaternion.identity;
		newQuat.eulerAngles = newRotationEuler;
		transform.rotation = newQuat;
		/*
			//////////////////////////////////////////////////////////////////////////////////////////////////
			//////////From here and below are Barrel Rolls. Eliminate when building the true game.////////////
			//////////////////////////////////////////////////////////////////////////////////////////////////

			//Timer. Hit button (Axis switched from 0 to non-0) timer starts,
			//it resets when you go from 0 to non-0 again, and does a barrel roll if done within time.

			if (bankAxis == 0.0f) {
				buttonDown = false;
			}//not at 0;
			else if (buttonDown == false) {
				buttonDown = true;
				if (time < doubleTapDelay) {
					StartCoroutine("BarrelRollLeft");
				}
				time = 0.0f;
			}
			time += Time.deltaTime;
		}
		*/
		//}
		
		/*IEnumerator BarrelRollLeft()
	{
		inBarrelRoll = true;
		float t = 0.0f;

		Vector3 initialRotation = transform.rotation.eulerAngles;

		Vector3 goalRotation = initialRotation;
		goalRotation.z += 180.0f;

		Vector3 currentRotation = initialRotation;

		while(t < barrelRollDuration/2.0f)
		{
			currentRotation.z = Mathf.Lerp(initialRotation.z,goalRotation.z,t/(barrelRollDuration/2.0f));
			transform.rotation = Quaternion.Euler(currentRotation);
			t += Time.deltaTime;
			yield return null;
		}

		t = 0;
		initialRotation = transform.rotation.eulerAngles;
		goalRotation = initialRotation;
		goalRotation.z += 180.0f;

		while(t < barrelRollDuration/2.0f)
		{
			currentRotation.z = Mathf.Lerp(initialRotation.z,goalRotation.z,t/(barrelRollDuration/2.0f));
			transform.rotation = Quaternion.Euler(currentRotation);
			t += Time.deltaTime;
			yield return null;
		}
		inBarrelRoll = false;
	}*/
	}
}
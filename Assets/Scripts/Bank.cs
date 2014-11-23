using UnityEngine;
using System.Collections;

public class Bank : MonoBehaviour {
	public float doubleTapDelay = 0.2f;
	public float barrelRollDuration = 1.0f;

//	private float time = float.MaxValue;
//	private bool buttonDown = false;
//	private bool inBarrelRoll = false;

	// Update is called once per frame
	void Update () 
	{

			float bankAxis = Input.GetAxis ("Bank");

			//Single axis method (windows/keyboard)
			Vector3 newRotationEuler = transform.rotation.eulerAngles;
			newRotationEuler.z = -90 * bankAxis;
			Quaternion newQuat = Quaternion.identity;
			newQuat.eulerAngles = newRotationEuler;
			transform.rotation = newQuat;
			
		}
}
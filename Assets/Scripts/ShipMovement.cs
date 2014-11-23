using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour 
{

	public Vector2 movementSpeed = Vector2.one;
	public static int invert = -1;//nega 1 for invert pos 1 for not
	public float angleChangeSpeed = 120.0f;
	//public float angleChangeSpeed = 120.0f;

	void Start(){
		//Register for level changed events
//		ScoreManager.Instance.LevelChanged += LevelChanged;
	}

	void OnDestroy(){
//		ScoreManager.Instance.LevelChanged -= LevelChanged;
	}

	void OnDisable(){
//		ScoreManager.Instance.LevelChanged -= LevelChanged;
	}

	// Update is called once per frame
	void Update () 
	{
		//Invert Controls when "I" is pressed
		if (Input.GetButtonDown ("Invert Vertical")) {
			invert*=-1;
		}

		
		//Increase LateralMovement when a threshold is met.
		if(SpeedManager.Instance.currentSpeed >=100 && SpeedManager.Instance.currentSpeed < 150){
			movementSpeed.x = 35;
			movementSpeed.y = 35;
		}else	if(SpeedManager.Instance.currentSpeed >=150 && SpeedManager.Instance.currentSpeed < 200){
			movementSpeed.x = 40;
			movementSpeed.y = 40;
		}else	if(SpeedManager.Instance.currentSpeed >=200 && SpeedManager.Instance.currentSpeed < 250){
			movementSpeed.x = 45;
			movementSpeed.y = 45;
		}else	if(SpeedManager.Instance.currentSpeed >=250 && SpeedManager.Instance.currentSpeed < 300){
			movementSpeed.x = 50;
			movementSpeed.y = 50;
		}else	if(SpeedManager.Instance.currentSpeed >=300 && SpeedManager.Instance.currentSpeed < 350){
			movementSpeed.x = 55;
			movementSpeed.y = 55;
		}else	if(SpeedManager.Instance.currentSpeed ==350){
			movementSpeed.x = 60;
			movementSpeed.y = 60;
		}

		float horizontal = Input.GetAxis ("Horizontal") * movementSpeed.x; //Movement X

		//Keep the ship within horizontal boundaries
		if (transform.position.x >= 27) {
			horizontal = Input.GetAxis ("Horizontal") - 1;
		}
		if (transform.position.x <= -27) {
			horizontal = Input.GetAxis ("Horizontal") + 1;
		}

		float vertical = Input.GetAxis ("Vertical")*movementSpeed.y; //Movement Y

		//Keep the ship withing vertical boundaries
		if (transform.position.y >= 15) {
			if(invert == -1)			vertical = Input.GetAxis ("Vertical") + 1;
			//Invert if controls are inverted
			if(invert == 1)				vertical = Input.GetAxis ("Horizontal") - 1;
		}
		if (transform.position.y <= -15) {
			if(invert == -1)			vertical = Input.GetAxis ("Vertical") - 1;
			//Invert if controls are inverted
			if(invert == 1)				vertical = Input.GetAxis ("Horizontal") + 1;
		}

		//Alter the ships's angle when moving left or right
		Vector3 direction = new Vector3(horizontal,invert*vertical,0);
		Vector3 finalDirection = new Vector3(horizontal,invert*vertical,10.0f);
		transform.position += direction*/*movementSpeed**/Time.deltaTime;
		//if (horizontal != 0 || vertical != 0) {
		transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(finalDirection),Mathf.Deg2Rad*angleChangeSpeed);
		//}

		//Dash for other project
		/*if (Input.GetButton ("Fire2")) {
			movementSpeed = 20;
		} else {
			movementSpeed = 10;
		}*/
	}

	void LevelChanged(int newLevel){
		Debug.Log("ShipMovement: New Level Event Received! Level: " + newLevel);
	}
}

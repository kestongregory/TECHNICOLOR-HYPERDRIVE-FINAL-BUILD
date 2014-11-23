using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	//public Transform ShipMainCollider;
	public float targetDistance = 10.0f; //MODIFY THE DISTANCE BASED ON HOW FAST THE PLAYER IS GOING
	public float enemySpeed = 0.0f;
	public float delay = 0.0f;
	public float maxTime = 600.0f;
	//private bool wallCheck = false;
	public float shotDelay = 0.0f;
	public float shotMaxTime = 10.0f;
	//public int n = 0;


	public Rigidbody Bullet;
	public Transform Ship;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
		GameObject plane = GameObject.FindGameObjectWithTag ("Player");

		if(delay >= maxTime){
			transform.position += transform.forward*enemySpeed*Time.deltaTime;
		}else	if (transform.position.z - plane.transform.position.z <= targetDistance) {
			Vector3 newPosition = transform.position;
			newPosition.z = plane.transform.position.z + targetDistance;
			transform.position=newPosition;
			delay++;
			//transform.LookAt(ShipMainCollider);
			if(delay ==maxTime/2 /*|| delay == maxTime-10*/){
				Attack();
			}
	}
		/*if (Vector3.Project (plane.transform.position - transform.position, plane.transform.forward).magnitude <= targetDistance) 
		{
			transform.position += Vector3.Project ((plane.transform.position - transform.position).normalized, 
			    plane.transform.forward) - Vector3.Project (plane.transform.position - transform.position, plane.transform.forward);

			//Vector3 newPosition = transform.position;

			//newPosition.z = player.transform.position.z + targetDistance;
			//transform.position = newPosition;
		}*/ else {
			transform.position += transform.forward*enemySpeed*Time.deltaTime;
		}



	}

	public void Attack()
	{
		//transform.LookAt(LastPos.transform.position);
		//if (RayDirection.magnitude > 10)
		//{
		//	transform.position = Vector3.MoveTowards(transform.position, LastPos.transform.position, Time.deltaTime * vel);
		//}
		
		//else
		//{
			Rigidbody b = GameObject.Instantiate (Bullet, Ship.position, Ship.rotation) as Rigidbody;

			//b.AddForce(2000 * b.transform.forward);
		//}
	}

	public void Update(){


		//Push back enemy's stop position when certain speed thresholds are met
		//if (SpeedManager.Instance.currentSpeed >= 50 ||
		//	SpeedManager.Instance.currentSpeed < 100) {
		//	targetDistance = 100;
		/*}else*/ if (SpeedManager.Instance.currentSpeed >= 150 ||
		              SpeedManager.Instance.currentSpeed < 200) {
			targetDistance = 250;
		}else if (SpeedManager.Instance.currentSpeed >= 200 ||
		          SpeedManager.Instance.currentSpeed < 250) {
			targetDistance = 300;
		}else if (SpeedManager.Instance.currentSpeed >= 250 ||
		          SpeedManager.Instance.currentSpeed < 300) {
			targetDistance = 450;
		}else if (SpeedManager.Instance.currentSpeed >= 350){
			targetDistance = 500;
		}
		
		/*if(SpeedManager.Instance.currentSpeed >= 150 ||
		   SpeedManager.Instance.currentSpeed < 200){
			Debug.Log("Gotta Go Fast");
		}else 		if(SpeedManager.Instance.currentSpeed >= 200 ||
		           SpeedManager.Instance.currentSpeed < 250){
			Debug.Log("Much Fast");
		}else		if(SpeedManager.Instance.currentSpeed >= 250 ||
		          SpeedManager.Instance.currentSpeed < 300){
			Debug.Log("Bwaaaaaah");
		}else		if(SpeedManager.Instance.currentSpeed >= 350){
			Debug.Log("Okay, too fast");
		}*/
	}
}

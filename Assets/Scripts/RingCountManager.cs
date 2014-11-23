using UnityEngine;
using System.Collections;

public class RingCountManager : MonoBehaviour {

	//SINGLETON
	private static RingCountManager instance = null;
	public static RingCountManager Instance
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
		gameObject.name = "$RingCountManager";
	}
	//ENDSINGLETON

	public int currentRingCount;
	//public int UpMultiplierAmount = 1;

	// Use this for initialization
	void Start () {
		currentRingCount = 0;
	}
	
	//void OnGUI(){
	//	GUILayout.Label ("RING COUNT: " + currentRingCount);
	//}

	
	// Update is called once per frame
	void Update () {
		//transform.position += transform.forward * currentMultiply * Time.deltaTime;
		//DISPLAY TEST
		//if (currentRingCount%2 == 0)
		//{
			//ScoreManager.Instance.UpMultiplier (UpMultiplierAmount); //Up Multiplier by 1

		//}
	}
}

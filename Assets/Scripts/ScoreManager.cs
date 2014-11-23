using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	//public int currentLevel = 0;
	//public int[] levelScoreThresholds;
	public static int score = 0;
	public int score2 = score;
	public int highScore;
	public int HChighScore; 
	public bool Hardcore;

	//public delegate void LevelChangedEvent(int newlevel);
	//public event LevelChangedEvent LevelChanged;

	public GUIText scoreText;

	public void StoreHighscore(int newHighscore)
	{
		//Debug.Log ("Storing Normal Score");
		int oldHighscore = PlayerPrefs.GetInt("highScore", 0);
		if (newHighscore > oldHighscore) {
			PlayerPrefs.SetInt ("highScore", newHighscore);
			Debug.Log ("Storing New High Score");
		}
		PlayerPrefs.Save(); 
	}

	public void HCStoreHighscore(int newHCHighscore)
	{
		//Debug.Log ("Storing Hardcore Score");
		int oldHCHighscore = PlayerPrefs.GetInt("HChighScore", 0);
		if (newHCHighscore > oldHCHighscore) {
			PlayerPrefs.SetInt ("HChighScore", newHCHighscore);
			Debug.Log ("Storing New Hardcore High Score");
		}
		PlayerPrefs.Save(); 
	}

	
	/*void OnGUI(){
		GUILayout.Label ("Score: " + score + " X " + currentMultiply);
	}*/

	/////////////////////////////////////////////////////////////
	public int maxMultiply = 5;
	public int minMultiply= 1;
	public int currentMultiply;
	public int startMultiply;
	
	// Use this for initialization
	void Start () {
		score = 0;
		score2 = score;
		if (!PlayerPrefs.HasKey ("highScore")) 
			highScore = highScore;
		else
			highScore = PlayerPrefs.GetInt("highScore");
		if (!PlayerPrefs.HasKey ("HChighScore")) 
			HChighScore = HChighScore;
		else
			HChighScore = PlayerPrefs.GetInt ("HChighScore");
		currentMultiply = startMultiply;
		InvokeRepeating("scoreCounter", 0.01F, 0.01F);
	}
	
	//void OnGUI(){
	//	GUILayout.Label ("MULTIPLIER: " + currentMultiply);
	//}
	
	public void LowerMultiplier(int lowerAmount){
		if (lowerAmount < 0) {
			Debug.LogError ("Cannot post a negative value to LowerMultiplier. Please use UpMultiplier instead.");
			return;
		}
		
		currentMultiply -= lowerAmount;
		if (currentMultiply < minMultiply) {
			currentMultiply = minMultiply;
		}
	}
	
	public void UpMultiplier(int upAmount){
		if (upAmount < 0) {
			Debug.LogError("Cannot post a negative value to SpeedUpPlayer. Please use SpeedDownPlayer instead.");
			return;
		}
		currentMultiply += upAmount;

		if (currentMultiply > maxMultiply) {
			currentMultiply = maxMultiply;
			
		}
	}
	/////////////////////////////////////////////////////////////

	void Update(){
		
		//PlayerPrefs.DeleteAll (); //UNCOMMENT TO DESTROY SCORE DATA
		/*if (Input.GetButtonDown ("Fire1"))
		{
			UpMultiplier(1);
		}
		if (Input.GetButtonDown ("Fire2"))
		{
			LowerMultiplier(1);
		}*/
		//if (score % 100 == 0) {
		//				RandomEnemySpawner.scoreMet = true;
		//		} else
		//				RandomEnemySpawner.scoreMet = false;
		score2 = score;
		//gamestate handler
		//if(score > levelScoreThresholds[currentLevel]){
		//	currentLevel += 1;
			//send notification of some kind to the other objects that care
		//	LevelChanged(currentLevel);
		//}
	}

	#region SingletonAndAwake
	private static ScoreManager instance = null;
	public static ScoreManager Instance{
		get {return instance;}
	}
	void Awake(){
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
		gameObject.name = "$ScoreManager";
	}
	#endregion

	void scoreCounter()
	{
		score = score + (1 * currentMultiply);

		/*if (score > highScore) {
			highScore = score;
		}*/
		if(!Hardcore)
			scoreText.text = "Score: " + score  + "\nMultiplier: " + currentMultiply + "\nHigh Score: " + highScore;
		else
			scoreText.text = "Score: " + score  + "\nMultiplier: " + currentMultiply + "\nHigh Score: " + HChighScore;
	}
}

using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour 
{
	//ScoreManager score = new ScoreManager();
	//ScoreManager highScore = new ScoreManager();

	public GUISkin startSkin;
	public GUIText normScoreText;
	public GUIText HCScoreText;
	public string[] menuArray;
	public int selectedIndex = 0;
	string direction;
	public AudioClip buttonClick;
	
	// Use this for initialization
	void Start () 
	{
		menuArray = new string[2];
		menuArray[0] = "mainMenu";
		menuArray[1] = "resetScores";
	}
	
	// Update is called once per frame
	void Update () 
	{	
//		if(Input.GetButtonDown ("Fire2"))
//		   PlayerPrefs.DeleteAll();
		MenuSelector();
	}

	
	void OnGUI()
	{
		//GUILayout.Label ("Score: " + ScoreManager.score);

		if (PlayerPrefs.HasKey ("highScore")) 
			normScoreText.text = "" + PlayerPrefs.GetInt ("highScore");
		else
			normScoreText.text = "0";

		if (PlayerPrefs.HasKey ("HChighScore")) 
			HCScoreText.text = "" + PlayerPrefs.GetInt ("HChighScore");
		else
			HCScoreText.text = "0";
		//		if (health.isDead == true)
		//		{
		//		}

		GUI.skin = startSkin;
		GUI.SetNextControlName ("mainMenu");
		if (GUI.Button(new Rect(Screen.width/2-600,Screen.height/2 + 175,600,300), "Back to Main Menu"))
		{

			Debug.Log("WE HAVE TO GO BACK MARTY");
		}

		GUI.skin = startSkin;
		GUI.SetNextControlName ("resetScores");
		if (GUI.Button(new Rect(Screen.width/2 + 50,Screen.height/2 + 175,600,300), "Reset High Scores"))
		{
			PlayerPrefs.DeleteAll();
			Debug.Log("reset scores");
		}
		
		GUI.FocusControl (menuArray[selectedIndex]);
	}

	void MenuSelector()
	{
		if (Input.GetKeyDown("d") && selectedIndex != 1)
		{
			direction = "right";
			selectedIndex++;
			Debug.Log(selectedIndex);
			audio.PlayOneShot(buttonClick, 1);
		}
		
		else if (Input.GetKeyDown("a") && selectedIndex != 0)
		{
			direction = "left";
			selectedIndex--;
			Debug.Log(selectedIndex);
			audio.PlayOneShot(buttonClick, 1);
		}

		if (Input.GetKeyDown("return") && selectedIndex == 0)
		{
			Application.LoadLevel("MainMenu");
		}

		if (Input.GetKeyDown("return") && selectedIndex == 1)
		{
			PlayerPrefs.DeleteAll();
		}
	}
}

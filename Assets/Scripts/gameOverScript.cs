using UnityEngine;
using System.Collections;

public class gameOverScript : MonoBehaviour 
{
	public GUISkin startSkin;
	public string[] menuArray;
	public int selectedIndex = 0;
	string direction;

	Rect windowRect0 = new Rect(Screen.width/2 - 350, Screen.height/2 - 150, 700, 300);
	HealthManager health = new HealthManager();

	public GUIText scoreText;

	public AudioClip Select;

	// Use this for initialization
	void Start () 
	{
		menuArray = new string[2];
		menuArray[0] = "TryAgain";
		menuArray[1] = "MainMenu";

		if (ScoreManager.Instance.Hardcore == false)
		{
			ScoreManager.Instance.StoreHighscore (ScoreManager.Instance.score2);
		}

		else if (ScoreManager.Instance.Hardcore == true)
		{
			ScoreManager.Instance.HCStoreHighscore(ScoreManager.Instance.score2);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{	
		menuSelector();
	}

	void OnGUI()
	{
		GUI.skin = startSkin;
		GUI.SetNextControlName ("TryAgain");
		if (GUI.Button(new Rect(Screen.width/2 - 600,Screen.height/2 - 250,500,300), "Try Again"))
		{
			selectedIndex = 0;
			Debug.Log("try again");
		}
		
		GUI.skin = startSkin;
		GUI.SetNextControlName ("MainMenu");
		if (GUI.Button(new Rect(Screen.width/2 - 600,Screen.height/2 - 175,500,300), "Main Menu"))
		{
			selectedIndex = 1;
			Debug.Log("main menu");
		}

		if (ScoreManager.Instance.Hardcore == false)
		{
			if (ScoreManager.Instance.score2 > ScoreManager.Instance.highScore)
			{
				scoreText.text = "Score: " + ScoreManager.Instance.score2 + "\nHigh Score: " + ScoreManager.Instance.score2;
			}

			else
			{
				scoreText.text = "Score: " + ScoreManager.Instance.score2 + "\nHigh Score: " + ScoreManager.Instance.highScore;
			}
		}

		else if (ScoreManager.Instance.Hardcore == true)
		{
			if (ScoreManager.Instance.score2 > ScoreManager.Instance.HChighScore)
			{
				scoreText.text = "Score: " + ScoreManager.Instance.score2 + "\nHigh Score: " + ScoreManager.Instance.score2;
			}
			
			else
			{
				scoreText.text = "Score: " + ScoreManager.Instance.score2 + "\nHigh Score: " + ScoreManager.Instance.HChighScore;
			}
		}
		
		GUI.FocusControl (menuArray[selectedIndex]);
	}

	void menuSelector()
	{
		if (Input.GetKeyDown("s") && selectedIndex != 1)
		{
			direction = "down";
			selectedIndex++;
			audio.PlayOneShot(Select, 1);
		}
		
		else if (Input.GetKeyDown("w") && selectedIndex != 0)
		{
			direction = "up";
			selectedIndex--;
			audio.PlayOneShot(Select, 1);
		}
		
		if (Input.GetKeyDown("return") && selectedIndex == 0)
		{
			Application.LoadLevel("TestingPlayerMove");
			Debug.Log("try again");
		}
		
		if (Input.GetKeyDown("return") && selectedIndex == 1)
		{
			Application.LoadLevel("mainMenu");
			Debug.Log("main menu");
		}
	}

	public void DestroyAllGameObjects()
	{
		GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
		
		for (int i = 0; i < GameObjects.Length; i++)
		{
			Destroy(GameObjects[i]);
		}
	}
}

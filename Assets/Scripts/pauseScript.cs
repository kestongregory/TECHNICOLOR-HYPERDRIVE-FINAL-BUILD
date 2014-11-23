using UnityEngine;
using System.Collections;

public class pauseScript : MonoBehaviour 
{
	Rect windowRect0 = new Rect(Screen.width/2 - 350, Screen.height/2 - 150, 700, 300);
	public bool isPaused = false;

	public GUISkin startSkin;

	public string[] menuArray;
	public int selectedIndex = 0;
	string direction;
	public AudioClip buttonClick;

//	// Use this for initialization
	void Start () 
	{
		menuArray = new string[2];
		menuArray[0] = "Resume";
		menuArray[1] = "MainMenu";
	}
	
//	// Update is called once per frame
	void Update () 
	{
		if (isPaused == false && Input.GetKeyDown("escape")) 
		{
			Debug.Log("paused");
			Time.timeScale = 0.0f;
			isPaused = true;
		}

		else if (isPaused == true && Input.GetKeyDown("escape"))
		{
			Debug.Log("unpaused");
			Time.timeScale = 1.0f;
			isPaused = false;
		}

		menuSelector();
	}

	void DoMyWindow(int windowID) 
	{
		GUI.skin = startSkin;
		GUI.SetNextControlName ("Resume");
		if (GUI.Button(new Rect(Screen.width/2 - 450, Screen.height/2 - 400, 400, 200), "Resume"))
		{
			isPaused = false;
			Time.timeScale = 1.0f;
			selectedIndex = 0;
			print("Resume");
		}
	
		GUI.skin = startSkin;
		GUI.SetNextControlName ("MainMenu");
		if (GUI.Button(new Rect(Screen.width/2 - 485, Screen.height/2 - 250, 400, 200), "Main Menu"))
		{
			Application.LoadLevel("mainMenu");
			print("quit");
			Time.timeScale = 1.0f;
			selectedIndex = 1;
			DestroyAllGameObjects();
		}
	}

	void OnGUI ()
	{
		if (isPaused == true)
		{
			windowRect0 = GUI.Window(0, windowRect0, DoMyWindow, "PAUSED");
		}

		GUI.FocusControl (menuArray[selectedIndex]);
	}

	public void DestroyAllGameObjects()
	{
		GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
		
		for (int i = 0; i < GameObjects.Length; i++)
		{
			Destroy(GameObjects[i]);
		}
	}

	void menuSelector()
	{
		if (isPaused == true)
		{
			if (Input.GetKeyDown("s") && selectedIndex != 1)
			{
				direction = "down";
				selectedIndex++;
				audio.PlayOneShot(buttonClick, 1);
			}
			
			else if (Input.GetKeyDown("w") && selectedIndex != 0)
			{
				direction = "up";
				selectedIndex--;
				audio.PlayOneShot(buttonClick, 1);
			}
			
			if (Input.GetKeyDown("return") && selectedIndex == 0)
			{
				isPaused = false;
				Time.timeScale = 1.0f;
				selectedIndex = 0;
				print("Resume");
			}
			
			if (Input.GetKeyDown("return") && selectedIndex == 1)
			{
				Application.LoadLevel("mainMenu");
				print("quit");
				Time.timeScale = 1.0f;
				selectedIndex = 1;
				DestroyAllGameObjects();
			}
		}
	}
}

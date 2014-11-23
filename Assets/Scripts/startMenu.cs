using UnityEngine;
using System.Collections;

public class startMenu : MonoBehaviour 
{
	public GUISkin startSkin;
	public GUISkin quitSkin;
	public GUISkin invertSkin;
	public string[] menuArray;
	public string[] invertArray;
	public string[] invertArrayHardcore;
	public int selectedIndex = 0;
	public int invertIndex = 0;
	public int invertIndexHardcore = 0;
	string direction;
	bool invertChoiceNormal = false;
	bool invertChoiceHardcore = false;
	bool hasBeenSelected = false;

	public AudioClip buttonClick;
	public AudioClip buttonSelect;
	
	// Use this for initialization
	void Start () 
	{
		menuArray = new string[7];
		menuArray[0] = "Start";
		menuArray[1] = "Hardcore";
		menuArray[2] = "HowToPlay";
		menuArray[3] = "HighScores";
		menuArray[4] = "Credits";
		menuArray[5] = "Quit";
		menuArray[6] = "BLANK";

		invertArray = new string[4];
		invertArray[0] = "Yes";
		invertArray[1] = "No";

		invertArrayHardcore = new string[2];
		invertArrayHardcore[0] = "Yes";
		invertArrayHardcore[1] = "No";
	}

	// Update is called once per frame
	void Update () 
	{
		menuSelector();
	}

	void OnGUI () 
	{
		GUI.skin = startSkin;
		GUI.SetNextControlName ("Start");
		if (GUI.Button(new Rect(Screen.width/2 - 600,Screen.height/2 - 275,500,300), "Normal Mode"))
		{
			selectedIndex = 0;
			Debug.Log("start");
		}

		GUI.skin = startSkin;
		GUI.SetNextControlName ("Hardcore");
		if (GUI.Button(new Rect(Screen.width/2 - 600,Screen.height/2 - 200,500,300), "Hardcore Mode"))
		{
			selectedIndex = 1;
			Debug.Log("hardcore");
		}

		GUI.skin = startSkin;
		GUI.SetNextControlName ("HowToPlay");
		if (GUI.Button(new Rect(Screen.width/2 - 600,Screen.height/2 - 125,500,300), "How to Play"))
		{
			selectedIndex = 2;
			Debug.Log("How to play");
		}

		GUI.skin = startSkin;
		GUI.SetNextControlName ("HighScores");
		if (GUI.Button(new Rect(Screen.width/2 - 600,Screen.height/2 - 50,500,300), "High Scores"))
		{
			selectedIndex = 3;
			Debug.Log("High score");
		}

		GUI.skin = startSkin;
		GUI.SetNextControlName ("Credits");
		if (GUI.Button(new Rect(Screen.width/2 - 600,Screen.height/2 + 25,500,300), "Credits"))
		{
			selectedIndex = 3;
			Debug.Log("credits");
		}

		GUI.skin = startSkin;
		GUI.SetNextControlName ("Quit");
		if (GUI.Button(new Rect(Screen.width/2 - 600,Screen.height/2 + 100,500,300), "Quit"))
		{
			selectedIndex = 4;
			Debug.Log("quit");
		}

		GUI.FocusControl (menuArray[selectedIndex]);

		if (invertChoiceNormal == true)
		{
			GUI.FocusControl (invertArray[invertIndex]);

			GUI.skin = quitSkin;
			GUI.Label(new Rect(Screen.width/2 - 500,Screen.height/2 - 350,1000,300), "Invert controls?");

			GUI.skin = invertSkin;
			GUI.SetNextControlName ("Yes");
			if (GUI.Button(new Rect(Screen.width/2 - 150,Screen.height/2 - 275,500,300), "Yes"))
			{
				invertIndex = 0;
				Debug.Log("inverted");
			}
			
			GUI.skin = invertSkin;
			GUI.SetNextControlName ("No");
			if (GUI.Button(new Rect(Screen.width/2 ,Screen.height/2 - 275,500,300), "No"))
			{
				invertIndex = 1;
				Debug.Log("not inverted");
			}
		}

		else if (invertChoiceHardcore == true)
		{
			GUI.FocusControl (invertArrayHardcore[invertIndexHardcore]);
			Debug.Log("invertIndexHardcore = " + invertIndexHardcore);
			
			GUI.skin = quitSkin;
			GUI.Label(new Rect(Screen.width/2 - 500,Screen.height/2 - 350,1000,300), "Invert controls?");
			
			GUI.skin = invertSkin;
			GUI.SetNextControlName ("Yes");
			if (GUI.Button(new Rect(Screen.width/2 - 150,Screen.height/2 - 200,500,300), "Yes"))
			{
				invertIndexHardcore = 2;
				Debug.Log("inverted");
			}
			
			GUI.skin = invertSkin;
			GUI.SetNextControlName ("No");
			if (GUI.Button(new Rect(Screen.width/2 ,Screen.height/2 - 200,500,300), "No"))
			{
				invertIndexHardcore = 3;
				Debug.Log("not inverted");
			}
		}
	}

	void menuSelector()
	{
		if (Input.GetKeyDown("s") && selectedIndex != 5)
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
		///////////////////////////////////////////////////////

		if (invertChoiceNormal == true)
		{
			selectedIndex = 6;
			if (Input.GetKeyDown("d") && invertIndex != 1)
			{
				direction = "right";
				invertIndex++;
				audio.PlayOneShot(buttonClick, 1);
			}
			
			else if (Input.GetKeyDown("a") && invertIndex != 0)
			{
				direction = "left";
				invertIndex--;
				audio.PlayOneShot(buttonClick, 1);
			}
		}

		else if (invertChoiceHardcore == true)
		{
			selectedIndex = 6;
			if (Input.GetKeyDown("d") && invertIndexHardcore != 1)
			{
				direction = "right";
				invertIndexHardcore++;
				Debug.Log(invertIndexHardcore);
				audio.PlayOneShot(buttonClick, 1);
			}
			
			else if (Input.GetKeyDown("a") && invertIndexHardcore != 0)
			{
				direction = "left";
				invertIndexHardcore--;
				Debug.Log(invertIndexHardcore);
				audio.PlayOneShot(buttonClick, 1);

			}
		}

		///////////////////////////////////////////////////////

		if (Input.GetKeyDown("return") && selectedIndex == 0)
		{
			invertChoiceNormal = true;
			Debug.Log("normal mode");
			audio.PlayOneShot(buttonSelect, 1);
		}

		if (Input.GetKeyDown("return") && selectedIndex == 1)
		{
			invertChoiceHardcore = true;
			Debug.Log("HARDCORE MODE");
			audio.PlayOneShot(buttonSelect, 1);
		}

		if (Input.GetKeyDown("return") && selectedIndex == 2)
		{
			Application.LoadLevel("howToPlay");
			Debug.Log("how to play");
			//audio.PlayOneShot(buttonSelect, 1);
		}

		if (Input.GetKeyDown("return") && selectedIndex == 3)
		{
			Application.LoadLevel("HighScores");
			Debug.Log("HighScores");
			//audio.PlayOneShot(buttonSelect, 1);
		}

		if (Input.GetKeyDown("return") && selectedIndex == 4)
		{
			Application.LoadLevel("creditsScene");
			Debug.Log("Credits");
			//audio.PlayOneShot(buttonSelect, 1);
		}

		if (Input.GetKeyDown("return") && selectedIndex == 5)
		{
			Application.Quit();
			Debug.Log("I QUIT");
			//audio.PlayOneShot(buttonSelect, 1);
		}

		if (invertChoiceNormal == true)
		{
			if (Input.GetKeyDown("return"))
			{
				if (invertIndex == 0)
				{
					if (hasBeenSelected == true)
					{
						Application.LoadLevel("TestingPlayerMove");

						//invert = true;
						ShipMovement.invert*=1;

						Debug.Log("normal mode, invert = true " + invertIndex);
					}

					else
					{
						hasBeenSelected = true;
					}
				}

				else if (invertIndex == 1)
				{
					if (hasBeenSelected == true)
					{
						Application.LoadLevel("TestingPlayerMove");
						
						//invert = false;
						ShipMovement.invert*=-1;
						
						Debug.Log("normal mode, invert = false" + invertIndex);
					}

					else
					{
						hasBeenSelected = true;
					}
				}
			}
		}

		if (invertChoiceHardcore == true)
		{
			if (Input.GetKeyDown("return"))
			{
				if (invertIndexHardcore == 0)
				{
					if (hasBeenSelected == true)
					{
						Application.LoadLevel("HardcoreMode");
								
						//invert = false;
						ShipMovement.invert*=1;
								
						Debug.Log("hardcore mode, invert = true" + invertIndexHardcore);
					}

					else
					{
						hasBeenSelected = true;
					}
				}

				else if (invertIndexHardcore == 1)
				{
					if (hasBeenSelected == true)
					{
						Application.LoadLevel("HardcoreMode");
								
						//invert = false;
						ShipMovement.invert*=-1;

						Debug.Log("hardcore mode, invert = false" + invertIndexHardcore);
					}

					else
					{
						hasBeenSelected = true;
					}
				}
			}
		}
	}
}

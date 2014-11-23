using UnityEngine;
using System.Collections;

public class creditsScript : MonoBehaviour
{

	public GUISkin startSkin;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey("return"))
		{
			Application.LoadLevel("mainMenu");
		}
	}
	
	void OnGUI ()
	{
		GUI.skin = startSkin;
		GUI.SetNextControlName ("mainMenu");
		if (GUI.Button(new Rect(Screen.width/2-260,Screen.height/2 + 175,600,300), "Back to Main Menu"))
		{
			Application.LoadLevel("MainMenu");
			Debug.Log("WE HAVE TO GO BACK MARTY");
		}
		
		GUI.FocusControl ("mainMenu");
	}
}

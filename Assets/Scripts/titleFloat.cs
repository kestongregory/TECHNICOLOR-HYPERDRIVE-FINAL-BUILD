using UnityEngine;
using System.Collections;

public class titleFloat : MonoBehaviour 
{
	private bool CountBack = false;
	private float Speed = 0.01f;
	private float t = 0f;
	private float final_t;
	private bool MouseOver = false;
	
	// Update is called once per frame
	void Update () 
	{
		if (MouseOver) 
		{
			if (!CountBack) 
			{
				t += Speed;
				if (t >= 1f) CountBack = true;
			}
			else {
				t -= Speed;
				if (t <= Speed) CountBack = false;
			}
			final_t = t;
			print (CountBack + "("+final_t+")");
			renderer.material.color = Color.Lerp(Color.red, Color.green, final_t);
		}
	}
}

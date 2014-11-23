using UnityEngine;
using System.Collections;

public class changeTitleColor : MonoBehaviour 
{
	public bool lightChange = true;
	
	Color red = new Color32(255, 0, 0, 255);
	Color orange = new Color32(255, 135, 0, 255);
	Color yellow = new Color32(255, 255, 0, 255);
	Color green = new Color32(0, 255, 0, 255);
	Color blue = new Color32(0, 0, 255, 255);
	Color indigo = new Color32(75, 0, 130, 255);
	Color violet = new Color32(238, 130, 238, 255);

	public Light myLight;
	GameObject technicolor;
	
	// Use this for initialization
	void Start() 
	{
		myLight = GetComponent<Light>();
		StartCoroutine(Do());
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}

	IEnumerator Do()
	{
		while (lightChange)
		{
			myLight.color = red;
			yield return new WaitForSeconds(0.10f);
			myLight.color = orange;
			yield return new WaitForSeconds(0.10f);
			myLight.color = yellow;
			yield return new WaitForSeconds(0.10f);
			myLight.color = green;
			yield return new WaitForSeconds(0.10f);
			myLight.color = blue;
			yield return new WaitForSeconds(0.10f);
			myLight.color = indigo;
			yield return new WaitForSeconds(0.10f);
			myLight.color = violet;
			yield return new WaitForSeconds(0.10f);
		}
	}
}

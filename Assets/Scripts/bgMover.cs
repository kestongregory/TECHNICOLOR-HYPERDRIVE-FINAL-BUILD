using UnityEngine;
using System.Collections;

public class bgMover : MonoBehaviour 
{
	GameObject bgPlanes;
	public float bgScrollRate = 8;

	// Use this for initialization
	void Start () 
	{
		bgPlanes = GameObject.Find("bgPlane");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.up * Time.deltaTime / bgScrollRate, Space.World);
	}
}

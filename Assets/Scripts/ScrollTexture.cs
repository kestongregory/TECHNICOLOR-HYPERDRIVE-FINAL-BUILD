using UnityEngine;
using System.Collections;

public class ScrollTexture : MonoBehaviour
{
	public Vector2 scrollSpeed = Vector2.one;
	public float scrollSpeedX = 1;
	public float scrollSpeedY = 1;
	private Material not;

	void Start(){
		not = renderer.material;
	}

	// Update is called once per frame
	void Update () {
		scrollSpeed.x = scrollSpeedX;
		scrollSpeed.y = scrollSpeedY;
		not.mainTextureOffset += scrollSpeed * Time.deltaTime;
	}
}

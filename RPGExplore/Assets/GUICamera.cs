using UnityEngine;
using System.Collections;

public class GUICamera : MonoBehaviour {

	public GameObject noiseFilter;
	float offSetX;
	float offSetY;
	
	void Start () 
	{
		InvokeRepeating("RunNoiseFilter", 0.0f, 0.1f);
	}
	
	#region Other
	
	void RunNoiseFilter()
	{
		offSetX = Random.Range(0.0f, 1.0f);
		offSetY = Random.Range(0.0f, 1.0f);
		noiseFilter.renderer.material.mainTextureOffset = new Vector2(offSetX, offSetY);
	}
	
	#endregion
}

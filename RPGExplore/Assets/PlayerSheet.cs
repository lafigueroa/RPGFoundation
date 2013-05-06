using UnityEngine;
using System.Collections;

public class PlayerSheet : MonoBehaviour {
	
	public int numFrames;
	public int curFrame = 1;
	
	float offSetX;
	
	void Start()
	{
		InvokeRepeating("DoStuff", 0.0f, 0.1f);
	}
	
	void DoStuff()
	{
//		offSetX += 0.1667f;
//		renderer.material.mainTextureOffset = new Vector2(offSetX, 0.0f);
//		curFrame += 1;
//		if(curFrame > numFrames)
//		{
//			renderer.material.mainTextureOffset = new Vector2(0.0f, 0.0f);
//			offSetX = 0.0f;
//			curFrame = 1;
//		}
	}
	
}
